﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
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
            RegistrarCasosDeUso(services);
        }



        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioAcessosGoogle, RepositorioAcessosGoogle>();
            services.TryAddScoped<IRepositorioExecucaoControle, RepositorioExecucaoControle>();

            services.TryAddScoped<IRepositorioCursoErro, RepositorioCursoErro>();
            services.TryAddScoped<IRepositorioUsuarioErro, RepositorioUsuarioErro>();
            services.TryAddScoped<IRepositorioCursoEol, RepositorioCursoEol>();
            services.TryAddScoped<IRepositorioCurso, RepositorioCurso>();
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
        }


        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<ITrataSyncGoogleGeralUseCase, TrataSyncGoogleGeralUseCase>();
            services.TryAddScoped<IIncluirCursoUseCase, IncluirCursoUseCase>();
            services.TryAddScoped<IObterCursosCadastradosUseCase, ObterCursosCadastradosUseCase>();
            services.TryAddScoped<IObterCursosParaIncluirGoogleUseCase, ObterCursosParaIncluirGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleUsuarioUseCase, TrataSyncGoogleUsuarioUseCase>();
            services.TryAddScoped<IObterAlunosCadastradosUseCase, ObterAlunosCadastradosUseCase>();
        }
    }
}
