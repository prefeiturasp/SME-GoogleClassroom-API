using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SME.GoogleClassroom.IoC
{
    public static class SqlServerHealthCheckExtension
    {
        public static IHealthChecksBuilder AddSqlServerEol(this IHealthChecksBuilder builder, IConfiguration configuration)
        {
            return AddSqlServer(builder, configuration.GetConnectionString("EolConnection"), "SqlServer_Eol");
        }

        private static IHealthChecksBuilder AddSqlServer(IHealthChecksBuilder builder, string connectionString, string nome)
        {
            return builder.AddSqlServer(connectionString,
                                        name: nome,
                                        failureStatus: HealthStatus.Unhealthy);
        }
    }
}
