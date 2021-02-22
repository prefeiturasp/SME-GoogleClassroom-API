using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.GoogleClassrom.Dados;
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
            RegistrarMapeamentos.Registrar();
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
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScoped<IRepositorioAcessosGoogle, RepositorioAcessosGoogle>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.TryAddSingleton<IServicoGoogleClassroom, ServicoGoogleClassroom>();
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<ITesteGoogleClassUseCase, TesteGoogleClassUseCase>();
            services.TryAddScoped<IObterDadosUsuarioPorLoginUseCase, ObterDadosUsuarioPorLoginUseCase>();
        }
    }
}
