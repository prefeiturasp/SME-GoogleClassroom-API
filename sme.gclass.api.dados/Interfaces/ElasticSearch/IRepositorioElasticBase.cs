using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioElasticBase<T> where T : class
    {
        Task<T> ObterAsync(string indice, string id, string nomeConsulta, object parametro = null);
        Task<IEnumerable<H>> ObterTodosAsync<H>(string indice, string nomeConsulta, object parametro = null) where H : class;
        Task<IEnumerable<H>> ObterListaAsync<H>(string indice, Func<QueryContainerDescriptor<H>, QueryContainer> request, string nomeConsulta, object parametro = null) where H : class;
        Task<long> ObterTotalDeRegistroAsync<H>(string indice, string nomeConsulta, object parametro = null) where H : class;
        Task<bool> ExisteAsync(string indice, string id, string nomeConsulta, object parametro = null);
        Task InserirBulk<H>(IEnumerable<H> listaDeDocumentos, string indice) where H : class;
    }
}
