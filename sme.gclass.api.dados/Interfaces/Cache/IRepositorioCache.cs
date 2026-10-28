using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces.Cache
{
    public interface IRepositorioCache
    {
        Task SalvarRedisAsync(string nomeChave, object valor, int? minutosParaExpirar = null);
        Task RemoverRedisAsync(string nomeChave);
        Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int? minutosParaExpirar = null);
        Task<T> ObterRedisAsync<T>(string nomeChave);
        Task<bool> ExisteChaveAsync(string nomeChave);
        Task<string> ObterRedisToJsonAsync(string nomeChave, Func<Task<string>> buscarDados, int? minutosParaExpirar = null);
        Task<string> ObterRedisToJsonAsync(string nomeChave);
        Task SalvarRedisToJsonAsync(string nomeChave, string json, int? minutosParaExpirar = null);
    }
}