using Nest;
using Newtonsoft.Json;
using SME.Pedagogico.Infra;
using SME.Pedagogico.Interface;
using SME.Pedagogico.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Repository
{
    public abstract class RepositorioElasticBase<T> : IRepositorioElasticBase<T> where T : class
    {
        private const int QUANTIDADE_RETORNO = 200;
        private const string TEMPO_CURSOR = "10s";
        private const string NOME_TELEMETRIA = "Elastic";
        private readonly IElasticClient _elasticClient;
        private readonly IServicoTelemetria servicoTelemetria;

        protected RepositorioElasticBase(IElasticClient elasticClient, IServicoTelemetria servicoTelemetria)
        {
            _elasticClient = elasticClient;
            this.servicoTelemetria = servicoTelemetria;
        }

        public async Task<bool> ExisteAsync(string indice, string id, string nomeConsulta, object parametro = null)
        {
            ExistsResponse response = await servicoTelemetria.RegistrarComRetornoAsync<ExistsResponse>(async () => 
                                                                                        await _elasticClient.DocumentExistsAsync(DocumentPath<T>.Id(id).Index(indice)),
                                                                                        NOME_TELEMETRIA,
                                                                                        nomeConsulta,
                                                                                        indice,
                                                                                        parametro?.ToString());

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);

            return response.Exists;
        }

        public async Task<T> ObterAsync(string indice, string id, string nomeConsulta, object parametro = null)
        {
            GetResponse<T> response = await servicoTelemetria.RegistrarComRetornoAsync<GetResponse<T>>(async () => 
                                                                                        await _elasticClient.GetAsync(DocumentPath<T>.Id(id).Index(indice)),
                                                                                        NOME_TELEMETRIA,
                                                                                        nomeConsulta,
                                                                                        indice,
                                                                                        parametro?.ToString());

            if (response.IsValid)
                return response.Source;

            return null;
        }

        public async Task<IEnumerable<H>> ObterListaAsync<H>(string indice, Func<QueryContainerDescriptor<H>, QueryContainer> request, string nomeConsulta, object parametro = null)
            where H : class
        {
            var listaDeRetorno = new List<H>();

            ISearchResponse<H> response = await servicoTelemetria.RegistrarComRetornoAsync<ISearchResponse<H>>(async () =>
                                                                                       await _elasticClient.SearchAsync<H>(s => s.Index(indice)
                                                                                                                                .Query(request)
                                                                                                                                .Scroll(TEMPO_CURSOR)
                                                                                                                                .Size(QUANTIDADE_RETORNO)),
                                                                                       NOME_TELEMETRIA,
                                                                                       nomeConsulta, 
                                                                                       indice,
                                                                                       parametro?.ToString());

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);

            listaDeRetorno.AddRange(response.Documents);

            while (response.Documents.Any() && response.Documents.Count == QUANTIDADE_RETORNO)
            {
                response = await servicoTelemetria.RegistrarComRetornoAsync<ISearchResponse<H>>(async () => 
                                                                                        await _elasticClient.ScrollAsync<H>(TEMPO_CURSOR, response.ScrollId),
                                                                                        NOME_TELEMETRIA,
                                                                                        nomeConsulta + " scroll",
                                                                                        indice,
                                                                                        parametro?.ToString());
                listaDeRetorno.AddRange(response.Documents);
            }

            this._elasticClient.ClearScroll(new ClearScrollRequest(response.ScrollId));

            return listaDeRetorno;
        }

        public async Task<IEnumerable<H>> ObterTodosAsync<H>(string indice, string nomeConsulta, object parametro = null)
            where H : class
        {
            var search = new SearchDescriptor<T>(indice).MatchAll();
            ISearchResponse<H> response = await servicoTelemetria.RegistrarComRetornoAsync<ISearchResponse<T>>(async () => 
                                                                                await _elasticClient.SearchAsync<H>(search),
                                                                                NOME_TELEMETRIA,
                                                                                nomeConsulta,
                                                                                indice,
                                                                                parametro?.ToString());

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);

            return response.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<long> ObterTotalDeRegistroAsync<H>(string indice, string nomeConsulta, object parametro = null)
            where H : class
        {
            var search = new SearchDescriptor<H>(indice).MatchAll();
            ISearchResponse<H> response = await servicoTelemetria.RegistrarComRetornoAsync<ISearchResponse<T>>(async () => 
                                                                                await _elasticClient.SearchAsync<H>(search),
                                                                                NOME_TELEMETRIA,
                                                                                nomeConsulta,
                                                                                indice,
                                                                                parametro?.ToString());

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);

            return response.Total;
        }

        public async Task<bool> InserirAsync(T entidade, string indice)
        {
            var response = await servicoTelemetria.RegistrarComRetornoAsync<ISearchResponse<T>>(async () =>
                     await _elasticClient.IndexAsync(entidade, descriptor => descriptor.Index(indice)),
                NOME_TELEMETRIA,
                $"Insert {entidade.GetType().Name}",
                indice,
                JsonConvert.SerializeObject(entidade));

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);

            return true;
        }

        public async Task InserirBulk<H>(IEnumerable<H> listaDeDocumentos, string indice) where H : class
        {
            var response = await _elasticClient.BulkAsync(b => b
                        .Index(indice)
                        .UpdateMany(listaDeDocumentos, (bu, d) => bu.Doc(d).DocAsUpsert(true)));

            if (!response.IsValid && response.Errors)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);
        }
    }
}
