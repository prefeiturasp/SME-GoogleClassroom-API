using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ConnectionStrings(configuration));

            services.AdicionarMediatr();
            services.AdicionarValidadoresFluentValidation();

            RegistrarRepositorios(services);
            RegistrarContextos(services);
            RegistrarComandos(services);
            RegistrarConsultas(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);
        }

        private static void RegistrarComandos(IServiceCollection services)
        {
        }

        private static void RegistrarConsultas(IServiceCollection services)
        {
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioAcessosGoogle, RepositorioAcessosGoogle>();
            services.TryAddScoped<IRepositorioExecucaoControle, RepositorioExecucaoControle>();

            services.TryAddScoped<IRepositorioCursoErro, RepositorioCursoErro>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<ITrataSyncGoogleGeralUseCase, TrataSyncGoogleGeralUseCase>();
        }
    }
}
