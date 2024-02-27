using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Aplicacao.Interfaces.RemoverTurma;
using SME.GoogleClassroom.Aplicacao.Interfaces.Sga.FuncionariosProfessores;
using SME.GoogleClassroom.Aplicacao.Sga.FuncionariosProfessores;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Escola;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dados.Repositorios.Eol.Unidade;
using SME.GoogleClassroom.Dados.Turmas;
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
            services.TryAddScoped<IRepositorioFuncionarioIndiretoEol, RepositorioFuncionarioIndiretoEol>();
            services.TryAddScoped<IRepositorioCursoGsa, RepositorioCursoGsa>();
            services.TryAddScoped<IRepositorioCursoGsa, RepositorioCursoGsa>();
            services.TryAddScoped<IRepositorioUsuarioGsa, RepositorioUsuarioGsa>();
            services.TryAddScoped<IRepositorioUsuarioCursoGsa, RepositorioUsuarioCursoGsa>();

            services.TryAddScoped<IRepositorioCursoUsuarioRemovidoGsaErro, RepositorioCursoUsuarioRemovidoGsaErro>();
            services.TryAddScoped<IRepositorioCursoUsuarioRemovidoGsa, RepositorioCursoUsuarioRemovidoGsa>();
            
            services.TryAddScoped<IRepositorioAviso, RepositorioAviso>();            
            services.TryAddScoped<IRepositorioAtividade, RepositorioAtividade>();            
            services.TryAddScoped<IRepositorioUsuarioInativoErro, RepositorioUsuarioInativoErro>();
            services.TryAddScoped<IRepositorioUsuarioInativo, RepositorioUsuarioInativo>();
            services.TryAddScoped<IRepositorioEscolaEol, RepositorioEscolaEol>();
            services.TryAddScoped<IRepositorioParametrosEol, RepositorioParametrosEol>();
            services.TryAddScoped<IRepositorioUnidade, RepositorioUnidade>();

            // Carga Inicial
            services.TryAddScoped<IRepositorioCargaInicial, RepositorioCargaInicial>();

            //Curso Arquivado
            services.TryAddScoped<IRepositorioParametroSistema, RepositorioParametroSistema>();
            services.TryAddScoped<IRepositorioCursoArquivado, RepositorioCursoArquivado>();
            services.TryAddScoped<IRepositorioTurmaEscolaEol, RepositorioTurmaEscolaEol>();

            //Notas
            services.TryAddScoped<IRepositorioNota, RepositorioNota>();
            
            //Funcionario Removido
            services.TryAddScoped<ITratarFuncionarioRemovidosCursosUseCase, TratarFuncionarioRemovidosCursosUseCase>();

            services.TryAddScoped<IRepositorioDreEol, RepositorioDreEol>();
            services.TryAddScoped<IRepositorioComponenteCurricularFormacaoCidade, RepositorioComponenteCurricularFormacaoCidade>();
            
            //Celp
            services.TryAddScoped<IRepositorioConfiguracaoCelp, RepositorioConfiguracaoCelp>();
            services.TryAddScoped<IRepositorioCursoCelpEol, RepositorioCursoCelpEol>();

            //Elastic e BD SGA
            services.TryAddScoped<IRepositorioElasticTurma, RepositorioElasticTurma>();
            services.TryAddScoped<IRepositorioComponenteCurricularEol, RepositorioComponenteCurricularEol>();
            
            //Conecta formação
            services.TryAddScoped<IRepositorioConectaFormacao, RepositorioConectaFormacao>();
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<IIniciarSyncGoogleCursoUseCase, IniciarSyncGoogleCursoUseCase>();
            services.TryAddScoped<ITrataSyncGoogleGeralUseCase, TrataSyncGoogleGeralUseCase>();
            services.TryAddScoped<ITratarSyncGsaUseCase, TratarSyncGsaUseCase>();
            services.TryAddScoped<IIncluirCursoUseCase, InserirCursoGoogleUseCase>();
            services.TryAddScoped<IObterCursosCadastradosUseCase, ObterCursosCadastradosUseCase>();
            services.TryAddScoped<IObterCursosParaIncluirGoogleUseCase, ObterCursosParaIncluirGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursoUseCase, TrataSyncGoogleCursoUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleAlunoUseCase, IniciarSyncGoogleAlunoUseCase>();
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
            services.TryAddScoped<IIncluirProfessorCursoGoogleUseCase, IncluirProfessorCursoGoogleUseCase>();
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
            services.TryAddScoped<IEnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase, EnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase>();
            services.TryAddScoped<ITrataSyncGoogleFuncionarioIndiretoUseCase, TrataSyncGoogleFuncionarioIndiretoUseCase>();
            services.TryAddScoped<IObterFuncionariosIndiretosParaIncluirGoogleUseCase, ObterFuncionariosIndiretosParaIncluirGoogleUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleFuncionarioIndiretoUseCase, IniciarSyncGoogleFuncionarioIndiretoUseCase>();
            services.TryAddScoped<IInserirFuncionarioIndiretoGoogleUseCase, InserirFuncionarioIndiretoGoogleUseCase>();
            services.TryAddScoped<IObterFuncionariosIndiretosGoogleUseCase, ObterFuncionariosIndiretosGoogleUseCase>();
            services.TryAddScoped<ITrataSyncGoogleAlunoErrosUseCase, TrataSyncGoogleAlunoErrosUseCase>();
            services.TryAddScoped<IRealizarTratamentoAlunoErroUseCase, RealizarTratamentoAlunoErroUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleAlunoErrosUseCase, IniciarSyncGoogleAlunoErrosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleProfessorErrosUseCase, TrataSyncGoogleProfessorErrosUseCase>();
            services.TryAddScoped<IRealizarTratamentoProfessorErroUseCase, RealizarTratamentoProfessorErroUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleProfessorErrosUseCase, IniciarSyncGoogleProfessorErrosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleFuncionarioErrosUseCase, TrataSyncGoogleFuncionarioErrosUseCase>();
            services.TryAddScoped<IRealizarTratamentoFuncionarioErroUseCase, RealizarTratamentoFuncionarioErroUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleFuncionarioErrosUseCase, IniciarSyncGoogleFuncionarioErrosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursoUseCase, TrataSyncGoogleCursoUseCase>();
            services.TryAddScoped<IRealizarTratamentoCursoErroUseCase, RealizarTratamentoCursoErroUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleCursoErrosUseCase, IniciarSyncGoogleCursoErrosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleCursoErroUseCase, TrataSyncGoogleCursoErroUseCase>();
            services.TryAddScoped<ITrataAtualizacaoUsuarioGoogleClassroomIdUseCase, TrataAtualizacaoUsuarioGoogleClassroomIdUseCase>();
            services.TryAddScoped<IIniciaAtualizacaoUsuarioGoogleClassroomIdUseCase, IniciaAtualizacaoUsuarioGoogleClassroomIdUseCase>();
            services.TryAddScoped<IAtualizacaoUsuarioGoogleClassroomIdUseCase, AtualizacaoUsuarioGoogleClassroomIdUseCase>();
            services.TryAddScoped<IRemoverProfessorCursoGoogleUseCase, RemoverProfessorCursoGoogleUseCase>();
            services.TryAddScoped<IIncluirAtividadesGsaProcessarErroUseCase, IncluirAtividadesGsaProcessarErroUseCase>();
            services.TryAddScoped<IFuncionariosProfessoresEolUseCase, FuncionariosProfessoresEolUseCase>();
            
            

            services.TryAddScoped<IObterAlunosCursosUsuariosRemovidosUseCase, ObterAlunosCursosUsuariosRemovidosUseCase>();

            services.TryAddScoped<IIniciarProcessoCursosUsuariosRemoverGsaUseCase, IniciarProcessoCursosUsuariosRemoverGsaUseCase>();
            services.TryAddScoped<IRealizarCargaTurmasCursoUsuarioRemovidoUseCase, RealizarCargaTurmasCursoUsuarioRemovidoUseCase>();
            services.TryAddScoped<ITratarTurmaCursoUsuarioRemovidoUseCase, TratarTurmaCursoUsuarioRemovidoUseCase>();
            services.TryAddScoped<ITratarAlunosCursoUsuarioRemovidoUseCase, TratarAlunosCursoUsuarioRemovidoUseCase>();
            services.TryAddScoped<IAtualizarAlunosCursosUseCase, AtualizarAlunosCursosUseCase>();
            services.TryAddScoped<IObterAlunosQueSeraoRemovidosUseCase, ObterAlunosQueSeraoRemovidosUseCase>();            

            services.TryAddScoped<IObterAlunosQueSeraoRemovidosUseCase, ObterAlunosQueSeraoRemovidosUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleUsuariosRemovidosErrosUseCase, IniciarSyncGoogleUsuariosRemovidosErrosUseCase>();

            // Usuario Inativação (Aluno)
            services.TryAddScoped<IIniciarProcessoInativacaoUsuariosGsaUseCase, IniciarProcessoInativacaoUsuariosGsaUseCase>();
            services.TryAddScoped<IRealizarCargaAlunoInativacaoUsuarioUseCase, RealizarCargaAlunoInativacaoUsuarioUseCase>();
            services.TryAddScoped<ITratarAlunosInativacaoUsuarioUseCase, TratarAlunosInativacaoUsuarioUseCase>();
            services.TryAddScoped<IIncluirInativacaoUsuarioGsaUseCase, IncluirInativacaoUsuarioGsaUseCase>();
            services.TryAddScoped<IObterAlunosInativosUseCase, ObterAlunosInativosUseCase>();            
            services.TryAddScoped<IObterAlunosQueSeraoInativadosUseCase, ObterAlunosQueSeraoInativadosUseCase>();
            services.TryAddScoped<ITrataSyncGoogleAlunoInativoErroUseCase, TrataSyncGoogleAlunoInativoErroUseCase>();
            
            // Remover atribuicao professor x curso
            services.TryAddScoped<IObterProfessoresQueSeraoRemovidosUseCase, ObterProfessoresQueSeraoRemovidosUseCase>();
            services.TryAddScoped<IObterProfessoresRemovidosCursosUseCase, ObterProfessoresRemovidosCursosUseCase>();

            // Remover atribuicao funcionario x curso
            services.TryAddScoped<IIniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase, IniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase>();
            services.TryAddScoped<IObterFuncionariosQueSeraoRemovidosUseCase, ObterFuncionariosQueSeraoRemovidosUseCase>();

            services.TryAddScoped<IObterFuncionariosRemovidosCursosUseCase, ObterFuncionariosRemovidosCursosUseCase>();

            //Curso Arquivar
            services.TryAddScoped<ICarregarArquivamentoCursosExtintosUseCase, CarregarArquivamentoCursosExtintosUseCase>();
            services.TryAddScoped<ITratarArquivamentoCursosUseCase, TratarArquivamentoCursosUseCase>();
            services.TryAddScoped<ISincronizarArquivamentoCursosUseCase, SincronizarArquivamentoCursosUseCase>();
            services.TryAddScoped<IIniciarTratamentoErroCursoArquivadosTratarUseCase, IniciarTratamentoErroCursoArquivadosTratarUseCase>();
            services.TryAddScoped<IIniciarTratamentoErroCursoArquivadosSyncUseCase, IniciarTratamentoErroCursoArquivadosSyncUseCase>();
            services.TryAddScoped<IObterCursosExtintosParaArquivarPaginadoUseCase, ObterCursosExtintosParaArquivarPaginadoUseCase>();
            services.TryAddScoped<ICarregarArquivamentoCursosExtintosManualUseCase, CarregarArquivamentoCursosExtintosManualUseCase>();
            services.TryAddScoped<IObterCursosArquivadosPaginadoUseCase, ObterCursosArquivadosPaginadoUseCase>();

            services.TryAddScoped<ICarregarArquivamentoCursosUseCase, CarregarArquivamentoCursosUseCase>();

            services.TryAddScoped<IIniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase, IniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase>();

            // Usuario inativação (Professores, Funcionarios e Funcionários indiretos)
            services.TryAddScoped<IIniciarInativacaoProfessoresEFuncionariosUseCase, IniciarProcessoInativacaoProfessoresGsaUseCase>();
            services.TryAddScoped<ICarregarProfessoresEFuncionariosParaInativar, RealizarCargaProfessoresInativosUseCase>();
            services.TryAddScoped<ITratarProfessoresEFuncionariosParaInativarUseCase, TratarProfessoresInativosGsaUseCase>();
            services.TryAddScoped<ISyncProfessoresEFuncionariosInativarUseCase, SyncProfessoresInativosGsaUseCase>();
            services.TryAddScoped<IIniciarSyncProfessoresInativadosComErrosUseCase, IniciarSyncProfessoresInativadosComErrosUseCase>();
            services.TryAddScoped<IObterFuncionariosInativosUseCase, ObterFuncionariosInativosUseCase>();
            services.TryAddScoped<IObterFuncionariosQueSeraoInativadosUseCase, ObterFuncionariosQueSeraoInativadosUseCase>();
            services.TryAddScoped<IObterFuncionariosIndiretosQueSeraoInativadosUseCase, ObterFuncionariosIndiretosQueSeraoInativadosUseCase>();
            
            //Carga inicial
            services.TryAddScoped<ITrataSyncManualGoogleGeralUseCase, TrataSyncManualGoogleGeralUseCase>();
            services.TryAddScoped<IRemoverCursoGoogleClassroomUseCase, RemoverCursoGoogleClassroomUseCase>();

            // Arquivamento de cursos por ano e semestre
            services.TryAddScoped<IIniciarProcessoArquivarCursosPorAnoUseCase, IniciarProcessoArquivarCursosPorAnoUseCase>();
            services.TryAddScoped<IObterCursosParaArquivarPaginadoUseCase, ObterCursosParaArquivarPaginadoUseCase>();

            services.TryAddScoped<IObterNotasAtividadesAvaliativasUseCase, ObterNotasAtividadesAvaliativasUseCase>();
            services.TryAddScoped<ICargaInicialUseCase, CargaInicialUseCase>();
            services.TryAddScoped<IRemoverTurmaUseCase, RemoverTurmaUseCase>();

            #region Formação Cidade
            services.TryAddScoped<IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase, IniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase>();
            services.TryAddScoped<IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase, IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase>();
            
            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase, SincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase>();
            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase, SincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase>();

            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase, SincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase>();
            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase, SincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase>();

            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaCursoUseCase, SincronizacaoGsaFormacaoCidadeTurmaCursoUseCase>();
            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase, SincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase>();

            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase, SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase>();
            services.TryAddScoped<ISincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase, SincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase>();
            #endregion
            
            services.TryAddScoped<IObterAulasPorTurmaComponenteCurricularDataUseCase, ObterAulasPorTurmaComponenteCurricularDataUseCase>();
            
            services.TryAddScoped<ILancarFrequenciaUseCase, LancarFrequenciaUseCase>();

            RegistrarCasosDeUsoGsa(services);
            RegistrarCasosDeUsoSGA(services);
        }

        private static void RegistrarCasosDeUsoSGA(IServiceCollection services)
        {
            services.TryAddScoped<IObterAlunosAtivosUseCase, ObterAlunosAtivosUseCase>();
            services.TryAddScoped<IObterEscolasUseCase, ObterEscolasUseCase>();
        }


        private static void RegistrarCasosDeUsoGsa(IServiceCollection services)
        {
            services.TryAddScoped<IObterCursoGsaGoogleUseCase, ObterCursoGsaGoogleUseCase>();

            services.TryAddScoped<IAtribuirDonoCursoUseCase, AtribuirDonoCursoUseCase>();

            services.TryAddScoped<IAtribuirDonoCursoFormacaoCidadeUseCase, AtribuirDonoCursoFormacaoCidadeUseCase>();

            RegistrarCasosDeUsoSincronizacaoGsa(services);
        }

        private static void RegistrarCasosDeUsoSincronizacaoGsa(IServiceCollection services)
        {
            services.TryAddScoped<IIniciarCargaCursosGsaUseCase, IniciarCargaCursosGsaUseCase>();
            services.TryAddScoped<IRealizarCargaCursosGsaUseCase, RealizarCargaCursosGsaUseCase>();
            services.TryAddScoped<IProcessarCursoGsaUseCase, ProcessarCursoGsaUseCase>();
            services.TryAddScoped<IValidarCursosGsaUseCase, ValidarCursosGsaUseCase>();
            services.TryAddScoped<IObterCursosGsaUseCase, ObterCursosGsaUseCase>();
            services.TryAddScoped<IIniciarValidacaoCursosGsaUseCase, IniciarValidacaoCursosGsaUseCase>();

            services.TryAddScoped<IIniciarCargaUsuariosGsaUseCase, IniciarCargaUsuariosGsaUseCase>();
            services.TryAddScoped<IRealizarCargaUsuariosGsaUseCase, RealizarCargaUsuariosGsaUseCase>();
            services.TryAddScoped<IRealizarCargaUsuariosGsaComErrosUseCase, RealizarCargaUsuariosGsaComErrosUseCase>();
            
            services.TryAddScoped<IProcessarUsuarioGsaUseCase, ProcessarUsuarioGsaUseCase>();
            services.TryAddScoped<IProcessarUsuarioGsaComErrosUseCase, ProcessarUsuarioGsaComErrosUseCase>();

            services.TryAddScoped<IValidarUsuariosGsaUseCase, ValidarUsuariosGsaUseCase>();
            services.TryAddScoped<IObterUsuariosGsaUseCase, ObterUsuariosGsaUseCase>();
            services.TryAddScoped<IIniciarValidacaoUsuariosGsaUseCase, IniciarValidacaoUsuariosGsaUseCase > ();
            services.TryAddScoped<IIniciarSyncGoogleUsuariosErrosUseCase, IniciarSyncGoogleUsuariosErrosUseCase > ();
            services.TryAddScoped<IAtualizarEmailUsuarioUseCase, AtualizarEmailUsuarioUseCase> ();

            services.TryAddScoped<IObterAvisoUseCase, ObterAvisoUseCase>();
            services.TryAddScoped<IRealizarCargaCursoUsuariosGsaUseCase, RealizarCargaCursoUsuariosGsaUseCase>();
            services.TryAddScoped<IProcessarCursoUsuarioGsaUseCase, ProcessarCursoUsuarioGsaUseCase>();
            services.TryAddScoped<IObterCursosDoUsuarioGsaUseCase, ObterCursosDoUsuarioGsaUseCase>();
            services.TryAddScoped<ITratarProfessoresRemovidosCursosUseCase, TratarProfessoresRemovidosCursosUseCase>();

            services.TryAddScoped<ITrataSyncGoogleRemovidoAlunoCursoErroUseCase, TrataSyncGoogleRemovidoAlunoCursoErroUseCase>();
            
            // RemocaoUsuarioCursoGsa
            services.TryAddScoped<ISincronizarRemocaoUsuarioCursoGsaUseCase, SincronizarRemocaoUsuarioCursoGsaUseCase>();

            // Mural de Avisos
            services.TryAddScoped<IIniciarSyncGoogleMuralAvisosUseCase, IniciarSyncGoogleMuralAvisosUseCase>();
            services.TryAddScoped<IRealizarCargaMuralAvisosGsaUseCase, RealizarCargaMuralAvisosGsaUseCase>();
            services.TryAddScoped<ITratarImportacaoMuralAvisosCursoGsaUseCase, TratarImportacaoMuralAvisosCursoGsaUseCase>();
            services.TryAddScoped<IImportarMuralAvisosCursoGsaUseCase, ImportarMuralAvisosCursoGsaUseCase>();
            services.TryAddScoped<IIncluirAvisosGsaErroProcessarUseCase, IncluirAvisosGsaErroProcessarUseCase>();
            
            // Atividades Avaliativas
            services.TryAddScoped<IObterAtividadesUseCase, ObterAtividadesUseCase>();
            services.TryAddScoped<IIniciarSyncGoogleAtividadesUseCase, IniciarSyncGoogleAtividadesUseCase>();
            services.TryAddScoped<IRealizarCargaAtividadesGsaUseCase, RealizarCargaAtividadesGsaUseCase>();
            services.TryAddScoped<ITratarImportacaoAtividadesCursoGsaUseCase, TratarImportacaoAtividadesCursoGsaUseCase>();
            services.TryAddScoped<IImportarAtividadesCursoGsaUseCase, ImportarAtividadesCursoGsaUseCase>();

            //Notas
            services.TryAddScoped<ICarregarAtividadesParaSincronizarNotasUseCase, CarregarAtividadesParaSincronizarNotasUseCase>();
            services.TryAddScoped<ITratarImportacaoDeNotasDaAtividadeUseCase, TratarImportacaoDeNotasDaAtividadeUseCase>();
            services.TryAddScoped<IExecutarImportacaoDeNotasDaAtividadeUseCase, ExecutarImportacaoDeNotasDaAtividadeUseCase>();
            services.TryAddScoped<IImportarNotasGsaProcessarErroUseCase, ImportarNotasGsaProcessarErroUseCase>();
            services.TryAddScoped<IIniciarSincronizacaoNotasUseCase, IniciarSincronizacaoNotasUseCase>();
            
            //Celp
            services.TryAddScoped<ITratarSincronizacaoCursosCelpGoogleUseCase, TratarSincronizacaoCursosCelpGoogleUseCase>();
            services.TryAddScoped<IIncluirCursoCelpGoogleUseCase, IncluirCursoCelpGoogleUseCase>();
            services.TryAddScoped<ITratarSincronizacaoAlunosDoCursoCelpGoogleUseCase, TratarSincronizacaoAlunosDoCursoCelpGoogleUseCase>();
            services.TryAddScoped<IIncluirFuncionarioCursoCelpGoogleUseCase, IncluirFuncionarioCursoCelpGoogleUseCase>();
            services.TryAddScoped<IIncluirAlunoCelpGoogleUseCase, IncluirAlunoCelpGoogleUseCase>();
            services.TryAddScoped<IIncluirAlunoCursoCelpGoogleUseCase, IncluirAlunoCursoCelpGoogleUseCase>();
            services.TryAddScoped<ITratarAlunosCursoUsuarioRemovidoCelpUseCase, TratarAlunosCursoUsuarioRemovidoCelpUseCase>();
            
            //Conecta formação
            services.TryAddScoped<IListagemInscricoesConfirmadasUseCase, ListagemInscricoesConfirmadasUseCase>();
            services.TryAddScoped<IListagemDetalhamentoFormacaoUseCase, ListagemDetalhamentoFormacaoUseCase>();
            services.TryAddScoped<IListagemDeAreaPromotoraUseCase, ListagemDeAreaPromotoraUseCase>();
        }
    }
}