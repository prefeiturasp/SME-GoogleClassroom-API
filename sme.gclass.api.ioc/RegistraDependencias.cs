using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
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
            services.TryAddScoped<IRepositorioAlunoEol, RepositorioAlunoEol>();
            services.TryAddScoped<IRepositorioCurso, RepositorioCurso>();
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScoped<IRepositorioFuncionarioEol, RepositorioFuncionarioEol>();
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScoped<IRepositorioProfessorEol, RepositorioProfessorEol>();
            services.TryAddScoped<IRepositorioCursoUsuarioErro, RepositorioCursoUsuarioErro>();
            services.TryAddScoped<IRepositorioCursoUsuario, RepositorioCursoUsuario>();
        }


        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<IIniciarSyncGoogleCursoUseCase, IniciarSyncGoogleCursoUseCase>();
            services.TryAddScoped<ITrataSyncGoogleGeralUseCase, TrataSyncGoogleGeralUseCase>();
            services.TryAddScoped<IIncluirCursoUseCase, InserirCursoGoogleUseCase>();
            services.TryAddScoped<IObterCursosCadastradosUseCase, ObterCursosCadastradosUseCase>();
            services.TryAddScoped<IObterCursosParaIncluirGoogleUseCase, ObterCursosParaIncluirGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursoUseCase, TrataSyncGoogleCursoUseCase>();
            services.TryAddScoped<IIniciarSyncGooglAlunoUseCase, IniciarSyncGooglAlunoUseCase>();
            services.TryAddScoped<ITrataSyncGoogleAlunoUseCase, TrataSyncGoogleAlunoUseCase>();
            services.TryAddScoped<IIncluirAlunoUseCase, IncluirAlunoUseCase>();
            services.TryAddScoped<IObterAlunosCadastradosUseCase, ObterAlunosCadastradosUseCase>();
            services.TryAddScoped<IObterFuncionariosParaIncluirGoogleUseCase, ObterFuncionariosParaIncluirGoogleUseCase>();
            services.TryAddScoped<IObterFuncionariosGoogleUseCase, ObterFuncionariosGoogleUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleFuncionarioUseCase, IniciarSyncGoogleFuncionarioUseCase>();
            services.TryAddScoped<ITrataSyncGoogleFuncionarioUseCase, TrataSyncGoogleFuncionarioUseCase>();
            services.TryAddScoped<IInserirFuncionarioGoogleUseCase, InserirFuncionarioGoogleUseCase>();
            services.TryAddScoped<IObterProfessoresGoogleUseCase, ObterProfessoresGoogleUseCase>();
            services.TryAddScoped<IObterProfessoresParaIncluirGoogleUseCase, ObterProfessoresParaIncluirGoogleUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleProfessorUseCase, IniciarSyncGoogleProfessorUseCase>();
            services.TryAddScoped<ITrataSyncGoogleProfessorUseCase, TrataSyncGoogleProfessorUseCase>();
            services.TryAddScoped<IInserirProfessorGoogleUseCase, InserirProfessorGoogleUseCase>();
            services.TryAddScoped<IObterAlunosParaCadastrarUseCase, ObterAlunosParaCadastrarUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursosDoProfessorUseCase, TrataSyncGoogleCursosDoProfessorUseCase>();
            services.TryAddScoped<ITrataSyncGoogleAtribuicoesDosProfessoresUseCase, TrataSyncGoogleAtribuicoesDosProfessoresUseCase>();
            services.TryAddScoped<IInserirProfessorCursoGoogleUseCase, InserirProfessorCursoGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleProfessoresDoCursoUseCase, TrataSyncGoogleProfessoresDoCursoUseCase>();
            services.TryAddScoped<IObterProfessoresCursosGoogleUseCase, ObterProfessoresCursosGoogleUseCase>();
            services.TryAddScoped<IEnviarRequisicaoAtribuirProfessorCursoUseCase, EnviarRequisicaoAtribuirProfessorCursoUseCase>();
            services.TryAddScoped<IObterAtribuicoesDeCursosDosProfessoresUseCase, ObterAtribuicoesDeCursosDosProfessoresUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleAtribuicoesDosProfessoresUseCase, IniciarSyncGoogleAtribuicoesDosProfessoresUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursosDoAlunoUseCase, TrataSyncGoogleCursosDoAlunoUseCase>();
            services.TryAddScoped<IInserirAlunoCursoGoogleUseCase, InserirAlunoCursoGoogleUseCase>();
            services.TryAddScoped<IEnviarRequisicaoAtribuirAlunoCursoUseCase, EnviarRequisicaoAtribuirAlunoCursoUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursosGradesUseCase, TrataSyncGoogleCursosGradesUseCase>();
            services.TryAddScoped<IObterAlunosCursosGoogleUseCase, ObterAlunosCursosGoogleUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleGradesUseCase, IniciarSyncGoogleGradesUseCase>();
            services.TryAddScoped<IObterGradesDeCursosUseCase, ObterGradesDeCursosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleAlunosDoCursoUseCase, TrataSyncGoogleAlunosDoCursoUseCase>();
            services.TryAddScoped<IObterAlunosCursosParaCadastrarGoogleUseCase, ObterAlunosCursosParaCadastrarGoogleUseCase>();
            services.TryAddScoped<IObterCursosAlunosParaIncluirGoogleUseCase, ObterCursosAlunosParaIncluirGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursosDoFuncionarioUseCase, TrataSyncGoogleCursosDoFuncionarioUseCase>();
            services.TryAddScoped<IInserirFuncionarioCursoGoogleUseCase, InserirFuncionarioCursoGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleFuncionariosDoCursoUseCase, TrataSyncGoogleFuncionariosDoCursoUseCase>();
            services.TryAddScoped<IEnviarRequisicaoAtribuirFuncionarioCursoUseCase, EnviarRequisicaoAtribuirFuncionarioCursoUseCase>();
            services.TryAddScoped<IObterFuncionariosCursosGoogleUseCase, ObterFuncionariosCursosGoogleUseCase>();
            services.TryAddScoped<IObterFuncionariosCursosParaIncluirGoogleUseCase, ObterFuncionariosCursosParaIncluirGoogleUseCase>();
            services.TryAddScoped<IObterCursosFuncionariosParaIncluirGoogleUseCase, ObterCursosFuncionariosParaIncluirGoogleUseCase>();
        }
    }
}