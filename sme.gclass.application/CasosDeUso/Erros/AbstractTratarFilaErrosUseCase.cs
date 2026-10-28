using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using RabbitMQ.Client;
using Sentry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class AbstractTratarFilaErrosUseCase<T> : ITratarFilaErrosUseCase where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IAsyncPolicy _policy;

        public AbstractTratarFilaErrosUseCase(string filaErro, string filaProcesso, IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            FilaErro = filaErro;
            FilaProcesso = filaProcesso;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyPublicaFila);
        }

        public string FilaErro { get; }
        public string FilaProcesso { get; }

        public async Task<bool> Executar()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("ConfiguracaoRabbit:HostName")?.Value,
                UserName = _configuration.GetSection("ConfiguracaoRabbit:UserName")?.Value,
                Password = _configuration.GetSection("ConfiguracaoRabbit:Password")?.Value,
                VirtualHost = _configuration.GetSection("ConfiguracaoRabbit:Virtualhost")?.Value
            };

            return await _policy.ExecuteAsync(() => TratarMensagens(FilaErro, factory));
        }

        protected virtual async Task<IConnection> ObterConexaoRabbitAsync(ConnectionFactory factory)
            => await factory.CreateConnectionAsync();

        private async Task<bool> TratarMensagens(string fila, ConnectionFactory factory)
        {
            await using var conexaoRabbit = await ObterConexaoRabbitAsync(factory);
            await using var channel = await conexaoRabbit.CreateChannelAsync();

            while (true)
            {
                var mensagemFila = await channel.BasicGetAsync(fila, false);
                if (mensagemFila == null)
                    break;

                try
                {
                    var mensagem = Encoding.UTF8.GetString(mensagemFila.Body.ToArray());
                    var mensagemRabbit = JsonConvert.DeserializeObject<MensagemRabbit>(mensagem);
                    var dto = mensagemRabbit.ObterObjetoMensagem<T>();

                    var publicado = await _mediator.Send(new PublicaFilaRabbitCommand(FilaProcesso, dto));
                    if (publicado)
                    {
                        await channel.BasicAckAsync(mensagemFila.DeliveryTag, false);
                    }
                    else
                    {
                        await channel.BasicNackAsync(mensagemFila.DeliveryTag, false, requeue: true);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    await channel.BasicNackAsync(mensagemFila.DeliveryTag, false, requeue: true);
                    throw;
                }
            }

            return true;
        }
    }
}
