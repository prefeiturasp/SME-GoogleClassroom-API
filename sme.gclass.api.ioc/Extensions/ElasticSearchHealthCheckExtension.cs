using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Nest;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra
{
    public class ElasticSearchHealthCheck : IHealthCheck
    {
        private readonly IConfiguration configuration;
        public ElasticSearchHealthCheck(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public static string HealthCheckElasticEol(IConfiguration configuration, WaitForStatus waitForStatus = WaitForStatus.Red, bool logResults = false)
        {
            string message = string.Empty;
            var client = new ElasticClient(new Uri(configuration["ElasticSearch:Urls"]));
            var response = client.Cluster.Health(new ClusterHealthRequest() { WaitForStatus = waitForStatus });

            var healthColor = response.Status.ToString().ToLower();


            switch (healthColor)
            {
                case "green":
                    message = "A verificação de integridade do ElasticSearch Server retornou [GREEN]";
                    break;

                case "yellow":
                    message = "A verificação de integridade do ElasticSearch Server retornou [YELLOW] (yellow é normal para clusters de nó único) ";
                    break;

                default:
                    message = string.Format("Verificação de integridade do ElasticSearch Server retornada [{0}]", response.Status.ToString().ToUpper());
                    break;

            }


            return message;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var status = HealthCheckElasticEol(configuration);
                return HealthCheckResult.Healthy(status);
            }
            catch (Exception ex)
            {

                return HealthCheckResult.Healthy($"O serviço Elastic apresentou os problemas: {ex.Message}");
            }
        }
    }
}