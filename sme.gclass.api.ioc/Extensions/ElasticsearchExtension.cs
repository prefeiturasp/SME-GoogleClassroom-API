using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.IoC
{
    public static class ElasticSearchExtension
    {
        public static void RegistraElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var urls = configuration["ElasticSearch:Urls"];
            var usuario = configuration["ElasticSearch:Usuario"];
            var senha = configuration["ElasticSearch:Senha"];

            var nodes = new List<Uri>();

            if (urls.Contains(','))
            {
                string[] listaUrls = urls.Split(',');
                foreach (string url in listaUrls)
                    nodes.Add(new Uri(url));
            }
            else
            {
                nodes.Add(new Uri(urls));
            }
            var connectionPool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(connectionPool)
                .ServerCertificateValidationCallback((sender, cert, chain, errors) => true);

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
                settings = settings.BasicAuthentication(usuario, senha);

            var client = new ElasticClient(settings);

            RegistraMapeamento(client);

            services.AddSingleton<IElasticClient>(client);
        }

        private static void RegistraMapeamento(IElasticClient elasticClient)
        {
            elasticClient.Map<AlunoNaTurmaDTO>(map => map.Index(Indices.Index(IndicesElastic.INDICE_ALUNO_TURMA_DRE)).AutoMap());
            elasticClient.Map<TurmaComponentesDto>(map => map.Index(Indices.Index(IndicesElastic.INDICE_TURMA_COMPONENTES)).AutoMap());
        }
    }
}
