using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.Logging;
using SME.GoogleClassroom.Dados.Interfaces.Cache;
using SME.GoogleClassroom.Infra.EnvironmentVariables;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Repositorios.Cache
{
    public sealed class RepositorioCache : IRepositorioCache
    {
        private static readonly MessagePackSerializerOptions OpcoesSerializacao =
            MessagePackSerializerOptions.Standard
                .WithResolver(ContractlessStandardResolver.Instance);

        private readonly IDatabase _database;
        private readonly ILogger<RepositorioCache> _logger;
        private readonly string _prefixoChaves;
        private readonly int _minutosExpiracaoPadrao;

        public RepositorioCache(
            IConnectionMultiplexer connectionMultiplexer,
            RedisOptions options,
            ILogger<RepositorioCache> logger)
        {
            ArgumentNullException.ThrowIfNull(connectionMultiplexer);
            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(logger);

            if (options.MinutosExpiracaoPadrao <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(options.MinutosExpiracaoPadrao),
                    "O TTL padrão do cache precisa ser maior que zero.");
            }

            _database = connectionMultiplexer.GetDatabase();
            _logger = logger;
            _prefixoChaves = string.IsNullOrWhiteSpace(options.InstanceName)
                ? "googleclassroom:"
                : options.InstanceName;
            _minutosExpiracaoPadrao = options.MinutosExpiracaoPadrao;
        }

        public async Task SalvarRedisAsync(
            string nomeChave,
            object valor,
            int? minutosParaExpirar = null)
        {
            if (valor == null)
                return;

            RedisKey chave;
            TimeSpan expiracao;

            try
            {
                chave = CriarChave(nomeChave);
                expiracao = ObterExpiracao(minutosParaExpirar);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Parâmetros inválidos ao salvar chave de cache.");

                return;
            }

            try
            {
                var bytes = MessagePackSerializer.Serialize(
                    valor.GetType(),
                    valor,
                    OpcoesSerializacao);

                await _database.StringSetAsync(chave, bytes, expiracao);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Não foi possível salvar o valor no cache KeyDB para a chave lógica {CacheKey}.",
                    nomeChave);
            }
        }

        public async Task RemoverRedisAsync(string nomeChave)
        {
            try
            {
                await _database.KeyDeleteAsync(CriarChave(nomeChave));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Não foi possível remover a chave lógica {CacheKey} do cache KeyDB.",
                    nomeChave);
            }
        }

        public async Task<T> ObterRedisAsync<T>(
            string nomeChave,
            Func<Task<T>> buscarDados,
            int? minutosParaExpirar = null)
        {
            ArgumentNullException.ThrowIfNull(buscarDados);

            RedisKey chave;

            try
            {
                chave = CriarChave(nomeChave);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Chave de cache inválida; será consultada a origem.");

                return await buscarDados();
            }

            try
            {
                var bytes = await _database.StringGetAsync(chave);

                if (bytes.HasValue)
                {
                    try
                    {
                        return MessagePackSerializer.Deserialize<T>(
                            (byte[])bytes,
                            OpcoesSerializacao);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(
                            ex,
                            "Valor de cache inválido para {CacheKey}; será consultada a origem.",
                            nomeChave);

                        await TentarRemoverChaveAsync(chave, nomeChave);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Falha ao consultar KeyDB para {CacheKey}; será consultada a origem.",
                    nomeChave);
            }

            // A consulta à origem fica fora do bloco de tratamento do cache:
            // falhas reais da origem não são mascaradas.
            var dados = await buscarDados();

            if (dados != null)
            {
                await SalvarRedisAsync(
                    nomeChave,
                    dados,
                    minutosParaExpirar);
            }

            return dados;
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave)
        {
            try
            {
                var bytes = await _database.StringGetAsync(CriarChave(nomeChave));

                return bytes.HasValue
                    ? MessagePackSerializer.Deserialize<T>(
                        (byte[])bytes,
                        OpcoesSerializacao)
                    : default;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Falha ao obter {CacheKey} do KeyDB.",
                    nomeChave);

                return default;
            }
        }

        public async Task<bool> ExisteChaveAsync(string nomeChave)
        {
            try
            {
                return await _database.KeyExistsAsync(CriarChave(nomeChave));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Falha ao verificar {CacheKey} no KeyDB.",
                    nomeChave);

                return false;
            }
        }

        public async Task<string> ObterRedisToJsonAsync(
            string nomeChave,
            Func<Task<string>> buscarDados,
            int? minutosParaExpirar = null)
        {
            ArgumentNullException.ThrowIfNull(buscarDados);

            RedisKey chave;

            try
            {
                chave = CriarChave(nomeChave);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Chave de cache inválida; será consultada a origem.");

                return await buscarDados();
            }

            try
            {
                var bytes = await _database.StringGetAsync(chave);

                if (bytes.HasValue)
                {
                    try
                    {
                        return MessagePackSerializer.ConvertToJson(
                            (byte[])bytes,
                            OpcoesSerializacao);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(
                            ex,
                            "JSON inválido em cache para {CacheKey}; será consultada a origem.",
                            nomeChave);

                        await TentarRemoverChaveAsync(chave, nomeChave);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Falha ao consultar KeyDB para {CacheKey}; será consultada a origem.",
                    nomeChave);
            }

            var json = await buscarDados();

            if (!string.IsNullOrWhiteSpace(json))
            {
                await SalvarRedisToJsonAsync(
                    nomeChave,
                    json,
                    minutosParaExpirar);
            }

            return json;
        }

        public async Task<string> ObterRedisToJsonAsync(string nomeChave)
        {
            try
            {
                var bytes = await _database.StringGetAsync(CriarChave(nomeChave));

                return bytes.HasValue
                    ? MessagePackSerializer.ConvertToJson(
                        (byte[])bytes,
                        OpcoesSerializacao)
                    : default;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Falha ao obter JSON de {CacheKey} do KeyDB.",
                    nomeChave);

                return default;
            }
        }

        public async Task SalvarRedisToJsonAsync(
            string nomeChave,
            string json,
            int? minutosParaExpirar = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return;

            try
            {
                var bytes = MessagePackSerializer.ConvertFromJson(
                    json,
                    OpcoesSerializacao);

                await _database.StringSetAsync(
                    CriarChave(nomeChave),
                    bytes,
                    ObterExpiracao(minutosParaExpirar));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Não foi possível salvar JSON no cache KeyDB para {CacheKey}.",
                    nomeChave);
            }
        }

        private RedisKey CriarChave(string nomeChave)
        {
            if (string.IsNullOrWhiteSpace(nomeChave))
            {
                throw new ArgumentException(
                    "A chave lógica de cache não pode ser vazia.",
                    nameof(nomeChave));
            }

            return $"{_prefixoChaves}{nomeChave.Trim()}";
        }

        private TimeSpan ObterExpiracao(int? minutosParaExpirar)
        {
            var minutos = minutosParaExpirar ?? _minutosExpiracaoPadrao;

            if (minutos <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(minutosParaExpirar),
                    "O TTL precisa ser maior que zero.");
            }

            return TimeSpan.FromMinutes(minutos);
        }

        private async Task TentarRemoverChaveAsync(
            RedisKey chave,
            string nomeChave)
        {
            try
            {
                await _database.KeyDeleteAsync(chave);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(
                    ex,
                    "Não foi possível invalidar o valor inválido de {CacheKey}.",
                    nomeChave);
            }
        }
    }
}