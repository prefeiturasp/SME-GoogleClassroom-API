using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SME.GoogleClassroom.IoC
{
    public static class NpgSqlHealthCheckExtension
    {
        public static IHealthChecksBuilder AddPostgresGoogleClassroom(this IHealthChecksBuilder builder, IConfiguration configuration)
        {
            return AddPostgres(builder, configuration.GetConnectionString("GoogleClassroomConnection"), "Postgres_GoogleClassroom");
        }

        public static IHealthChecksBuilder AddPostgresApiEol(this IHealthChecksBuilder builder, IConfiguration configuration)
        {
            return AddPostgres(builder, configuration.GetConnectionString("ApiEolConnection"), "Postgres_ApiEol");
        }

        private static IHealthChecksBuilder AddPostgres(IHealthChecksBuilder builder, string connectionString, string nome)
        {
            return builder.AddNpgSql(connectionString,
                                     name: nome,
                                     failureStatus: HealthStatus.Unhealthy);
        }
    }
}
