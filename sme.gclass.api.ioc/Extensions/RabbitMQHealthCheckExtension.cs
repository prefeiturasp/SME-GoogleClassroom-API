using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.IoC
{
    public static class RabbitMQHealthCheckExtension
    {
        public static IHealthChecksBuilder AddRabbitMQ(this IHealthChecksBuilder builder, ConfiguracaoRabbitOptions configuracaoRabbit)
        {
            string connectionString = ObterStringConexao(
                                                configuracaoRabbit.UserName,
                                                configuracaoRabbit.Password,
                                                configuracaoRabbit.HostName,
                                                configuracaoRabbit.Virtualhost);

            return AddRabbitMQ(builder, connectionString, "RabbitMQ");
        }

        public static IHealthChecksBuilder AddRabbitMQLog(this IHealthChecksBuilder builder, ConfiguracaoRabbitLogOptions configuracaoRabbitLog)
        {
            string connectionString = ObterStringConexao(
                                                configuracaoRabbitLog.UserName,
                                                configuracaoRabbitLog.Password,
                                                configuracaoRabbitLog.HostName,
                                                configuracaoRabbitLog.VirtualHost);

            return AddRabbitMQ(builder, connectionString, "RabbitMQLog");
        }

        private static string ObterStringConexao(string userName, string password, string hostName, string virtualHost)
        {
            return $"amqp://{userName}:{password}@{hostName}/{virtualHost}";
        }

        private static IHealthChecksBuilder AddRabbitMQ(IHealthChecksBuilder builder, string connectionString, string nome)
        {
            return builder.AddRabbitMQ(
                    connectionString,
                    name: nome,
                    failureStatus: HealthStatus.Unhealthy);
        }
    }
}
