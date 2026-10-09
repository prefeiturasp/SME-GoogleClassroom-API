using Elastic.Apm;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public class WorkerRabbitMQ : IHostedService
    {
        private IChannel canalRabbit;
        private IConnection conexaoRabbit;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IMetricReporter metricReporter;
        private readonly IServicoTelemetria servicoTelemetria;
        private readonly ConsumoDeFilasOptions consumoDeFilasOptions;
        private readonly ConfiguracaoRabbitOptions configuracaoRabbitOptions;
        private readonly TelemetriaOptions telemetriaOptions;
        private readonly IMediator mediator;

        private readonly Dictionary<string, ComandoRabbit> comandos;

        public WorkerRabbitMQ(IConnection conexaoRabbit,
                              IServiceScopeFactory serviceScopeFactory,
                              IMetricReporter metricReporter,
                              IServicoTelemetria servicoTelemetria,
                              ConsumoDeFilasOptions consumoDeFilasOptions,
                              ConfiguracaoRabbitOptions configuracaoRabbitOptions,
                              TelemetriaOptions telemetriaOptions,
                              IMediator mediator)
        {
            this.conexaoRabbit = conexaoRabbit ?? throw new ArgumentNullException(nameof(conexaoRabbit));
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            this.telemetriaOptions = telemetriaOptions ?? throw new ArgumentNullException(nameof(telemetriaOptions));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.metricReporter = metricReporter;
            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
            this.consumoDeFilasOptions = consumoDeFilasOptions ?? throw new ArgumentNullException(nameof(consumoDeFilasOptions));
            this.configuracaoRabbitOptions = configuracaoRabbitOptions ?? throw new ArgumentNullException(nameof(configuracaoRabbitOptions));

            comandos = new Dictionary<string, ComandoRabbit>();
            RegistrarUseCases();
        }

        private void RegistrarUseCases()
        {
            comandos.Add(RotasRabbit.FilaGoogleSync, new ComandoRabbit("Tratamento geral do sync com google", typeof(ITrataSyncGoogleGeralUseCase)));
            comandos.Add(RotasRabbit.FilaCursoIncluir, new ComandoRabbit("Incluir cursos novos no google", typeof(IIncluirCursoUseCase)));
            comandos.Add(RotasRabbit.FilaCursoSync, new ComandoRabbit("Incluir cursos novos no google", typeof(ITrataSyncGoogleCursoUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoSync, new ComandoRabbit("Tratamento de alunos do sync com google", typeof(ITrataSyncGoogleAlunoUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoIncluir, new ComandoRabbit("Incluir alunos novos no Google", typeof(IIncluirAlunoUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioSync, new ComandoRabbit("Tratamento de funcionários do sync com Google", typeof(ITrataSyncGoogleFuncionarioUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioIncluir, new ComandoRabbit("Incluir funcionários novos no Google", typeof(IInserirFuncionarioGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorSync, new ComandoRabbit("Tratamento de professores do sync com Google", typeof(ITrataSyncGoogleProfessorUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorIncluir, new ComandoRabbit("Incluir professores novos no Google", typeof(IInserirProfessorGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorCursoSync, new ComandoRabbit("Tratamento de cursos do professor do sync com Google", typeof(ITrataSyncGoogleCursosDoProfessorUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorCursoAtribuicaoSync, new ComandoRabbit("Tratamento atribuições de cursos de professores do sync com Google", typeof(ITrataSyncGoogleAtribuicoesDosProfessoresUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorCursoIncluir, new ComandoRabbit("Atribuir professor ao curso no google", typeof(IIncluirProfessorCursoGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaCursoProfessorSync, new ComandoRabbit("Tratamentode professores do curso do sync com Google", typeof(ITrataSyncGoogleProfessoresDoCursoUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoCursoSync, new ComandoRabbit("Tratamento de cursos do aluno do sync com Google", typeof(ITrataSyncGoogleCursosDoAlunoUseCase)));
            comandos.Add(RotasRabbit.FilaCursoAlunoSync, new ComandoRabbit("Tratamento de alunos do curso do sync com Google", typeof(ITrataSyncGoogleAlunosDoCursoUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoCursoIncluir, new ComandoRabbit("Atribuir aluno ao curso no google", typeof(IInserirAlunoCursoGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaCursoGradeSync, new ComandoRabbit("Tratamento grades de cursos do sync com Google", typeof(ITrataSyncGoogleCursosGradesUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioCursoSync, new ComandoRabbit("Tratamento de cursos do funcionário do sync com Google", typeof(ITrataSyncGoogleCursosDoFuncionarioUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioCursoIncluir, new ComandoRabbit("Atribuir funcionário ao curso no google", typeof(IInserirFuncionarioCursoGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaCursoFuncionarioSync, new ComandoRabbit("Tratamento de funcionários do curso do sync com Google", typeof(ITrataSyncGoogleFuncionariosDoCursoUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioIndiretoSync, new ComandoRabbit("Tratamento de funcionários indiretos do sync com Google", typeof(ITrataSyncGoogleFuncionarioIndiretoUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioIndiretoIncluir, new ComandoRabbit("Incluir funcionários indiretos novos no Google", typeof(IInserirFuncionarioIndiretoGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoErroSync, new ComandoRabbit("Tratamento de erros na inclusão de alunos", typeof(ITrataSyncGoogleAlunoErrosUseCase)));
            comandos.Add(RotasRabbit.FilaAlunoErroTratar, new ComandoRabbit("Realiza o tratamento de erro na inclusão de um aluno.", typeof(IRealizarTratamentoAlunoErroUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorErroSync, new ComandoRabbit("Tratamento de erros na inclusão de professores", typeof(ITrataSyncGoogleProfessorErrosUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorErroTratar, new ComandoRabbit("Realiza o tratamento de erro na inclusão de um professor.", typeof(IRealizarTratamentoProfessorErroUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioErroSync, new ComandoRabbit("Tratamento de erros na inclusão de funcionários", typeof(ITrataSyncGoogleFuncionarioErrosUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioErroTratar, new ComandoRabbit("Realiza o tratamento de erro na inclusão de um funcionários.", typeof(IRealizarTratamentoFuncionarioErroUseCase)));
            comandos.Add(RotasRabbit.FilaCursoErroSync, new ComandoRabbit("Tratamento de erros cursos novos no sync com google", typeof(ITrataSyncGoogleCursoErroUseCase)));
            comandos.Add(RotasRabbit.FilaCursoErroTratar, new ComandoRabbit("Tratamento de erros cursos novos ao inserir no google", typeof(IRealizarTratamentoCursoErroUseCase)));
            comandos.Add(RotasRabbit.FilaUsuarioGoogleIdSync, new ComandoRabbit("Tratamento de atualização de usuários GoogleClassroomId", typeof(ITrataAtualizacaoUsuarioGoogleClassroomIdUseCase)));
            comandos.Add(RotasRabbit.FilaUsuarioGoogleIdAtualizar, new ComandoRabbit("Atualização de usuário GoogleClassroomId", typeof(IAtualizacaoUsuarioGoogleClassroomIdUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorCursoRemover, new ComandoRabbit("Remover professores novos no Google", typeof(IRemoverProfessorCursoGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaGoogleSync, new ComandoRabbit("Tratamento geral do sync com google", typeof(ITratarSyncGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoCarregar, new ComandoRabbit("Sincroniza os cursos GSA a serem adicionados na base", typeof(IRealizarCargaCursosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoIncluir, new ComandoRabbit("Processar curso GSA e adiciona na base", typeof(IProcessarCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoValidar, new ComandoRabbit("Realiza validação de cursos GSA", typeof(IValidarCursosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaUsuarioCarregar, new ComandoRabbit("Sincroniza os usuários GSA a serem adicionados na base", typeof(IRealizarCargaUsuariosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaUsuarioIncluir, new ComandoRabbit("Processar usuário GSA e adiciona na base", typeof(IProcessarUsuarioGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaUsuarioValidar, new ComandoRabbit("Realiza validação de usuários GSA", typeof(IValidarUsuariosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioCarregar, new ComandoRabbit("Sincroniza os cursos do usuário GSA a serem adicionados na base", typeof(IRealizarCargaCursoUsuariosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioIncluir, new ComandoRabbit("Processar curso do usuário GSA e adiciona na base", typeof(IProcessarCursoUsuarioGsaUseCase)));

            // Remover
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, new ComandoRabbit("Carregar turmas dos usuários para remoção de cursos", typeof(IRealizarCargaTurmasCursoUsuarioRemovidoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, new ComandoRabbit("Carregar turmas dos usuários para remoção de cursos", typeof(ITratarTurmaCursoUsuarioRemovidoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, new ComandoRabbit("Carregar codigos dos alunos para remoção de cursos", typeof(ITratarAlunosCursoUsuarioRemovidoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, new ComandoRabbit("Carregar codigos dos professores para remoção de cursos", typeof(ITratarProfessoresRemovidosCursosUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, new ComandoRabbit("Carregar codigos dos funcionários para remoção de cursos", typeof(ITratarFuncionarioRemovidosCursosUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, new ComandoRabbit("Sincroniza curso do usuário GSA e exclui registro", typeof(ISincronizarRemocaoUsuarioCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar, new ComandoRabbit("Sincroniza erro de exclusão de curso do usuário GSA e exclui registro", typeof(ITrataSyncGoogleRemovidoAlunoCursoErroUseCase)));

            // Inativação Alunos
            comandos.Add(RotasRabbit.FilaGsaInativarUsuarioIniciar, new ComandoRabbit("Inicia o processo de inativar alunos", typeof(IIniciarProcessoInativacaoUsuariosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaInativarUsuarioCarregar, new ComandoRabbit("Carregar alunos para inativação", typeof(IRealizarCargaAlunoInativacaoUsuarioUseCase)));
            comandos.Add(RotasRabbit.FilaGsaInativarUsuarioSync, new ComandoRabbit("Tratar os alunos GSA a serem inativados", typeof(ITratarAlunosInativacaoUsuarioUseCase)));
            comandos.Add(RotasRabbit.FilaGsaInativarUsuarioIncluir, new ComandoRabbit("Incluir na fila de inativação de alunos GSA ", typeof(IIncluirInativacaoUsuarioGsaUseCase)));
            comandos.Add(RotasRabbit.FilaUsuarioGoogleTratarErro, new ComandoRabbit("Incluir na fila de erro na inativação de alunos GSA ", typeof(ITrataSyncGoogleAlunoInativoErroUseCase)));

            // Mural
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosCarregar, new ComandoRabbit("Sincroniza os avisos do mural GSA a serem carregados na base", typeof(IRealizarCargaMuralAvisosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosTratar, new ComandoRabbit("Tratar os avisos do mural GSA a serem carregados na base", typeof(ITratarImportacaoMuralAvisosCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosIncluir, new ComandoRabbit("Incluir os avisos do mural GSA a serem carregados na base", typeof(IImportarMuralAvisosCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaAtividadesCarregar, new ComandoRabbit("Sincroniza os avisos do mural GSA a serem carregados na base", typeof(IRealizarCargaAtividadesGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaAtividadesTratar, new ComandoRabbit("Sincroniza os avisos do mural GSA a serem carregados na base", typeof(ITratarImportacaoAtividadesCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaAtividadesIncluir, new ComandoRabbit("Incluir os avisos do mural GSA a serem carregados na base", typeof(IImportarAtividadesCursoGsaUseCase)));

            // Arquivamento de Cursos - (Anual / Extintos)
            comandos.Add(RotasRabbit.FilaCursoExtintoArquivarCarregar, new ComandoRabbit("Carregar arquivamento de cursos extintos no EOL", typeof(ICarregarArquivamentoCursosExtintosUseCase)));
            comandos.Add(RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar, new ComandoRabbit("Carregar arquivamento de cursos arquivados para o ano e semestre EOL", typeof(IIniciarProcessoArquivarCursosPorAnoUseCase)));
            comandos.Add(RotasRabbit.FilaCursoArquivarCarregar, new ComandoRabbit("Carregar cursos do EOL para arquivamento", typeof(ICarregarArquivamentoCursosUseCase)));

            comandos.Add(RotasRabbit.FilaCursoArquivarTratar, new ComandoRabbit("Tratar arquivamento de cursos no EOL", typeof(ITratarArquivamentoCursosUseCase)));
            comandos.Add(RotasRabbit.FilaCursoArquivarSync, new ComandoRabbit("Tratar arquivamento de cursos no EOL", typeof(ISincronizarArquivamentoCursosUseCase)));

            // Inativação Professores, Funcionários e Funcionários indiretos
            comandos.Add(RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar, new ComandoRabbit("Inicia o processo de inativar professores, funcionários e funcionários indiretos", typeof(IIniciarInativacaoProfessoresEFuncionariosUseCase)));
            comandos.Add(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, new ComandoRabbit("Carregar professores, funcionários e funcionários indiretos que devem ser inativados", typeof(ICarregarProfessoresEFuncionariosParaInativar)));
            comandos.Add(RotasRabbit.FilaTratarProfessoresEFuncionariosInativar, new ComandoRabbit("Tratar os professores, funcionários e funcionários indiretos que devem ser inativados", typeof(ITratarProfessoresEFuncionariosParaInativarUseCase)));
            comandos.Add(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, new ComandoRabbit("Sincroniza a inativação de professores, funcionários e funcionários indiretos", typeof(ISyncProfessoresEFuncionariosInativarUseCase)));
            comandos.Add(RotasRabbit.FilaInativarProfessorErroTratar, new ComandoRabbit("Tratar erros na fila de erro na inativação de professores, funcionários e funcionários indiretos", typeof(IIniciarSyncProfessoresInativadosComErrosUseCase)));

            // Notas
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesCarregar, new ComandoRabbit("Carrega atividades para importacao de notas", typeof(ICarregarAtividadesParaSincronizarNotasUseCase)));
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesTratar, new ComandoRabbit("Tratar carga de notas das atividades para importacao", typeof(ITratarImportacaoDeNotasDaAtividadeUseCase)));
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesSync, new ComandoRabbit("Executar importação de notas da atividade", typeof(IExecutarImportacaoDeNotasDaAtividadeUseCase)));
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesSyncErro, new ComandoRabbit("Gravar erros na importação das notas", typeof(IImportarNotasGsaProcessarErroUseCase)));

            // Carga Inicial
            comandos.Add(RotasRabbit.FilaGsaCargaInicial, new ComandoRabbit("Carga inicial executada manualmente", typeof(ITrataSyncManualGoogleGeralUseCase)));
            comandos.Add(RotasRabbit.FilaCursoAhRemover, new ComandoRabbit("Remover curso", typeof(IRemoverCursoGoogleClassroomUseCase)));

            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA por SME ou DRE", typeof(ISincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA por Componente", typeof(ISincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA - criação do Curso", typeof(ISincronizacaoGsaFormacaoCidadeTurmaCursoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA - atribuição de Aluno", typeof(ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase)));

            // Celp
            comandos.Add(RotasRabbit.FilaGsaCursosCelpSync, new ComandoRabbit("Sincroniza os cursos do Celp no Google com base na configuração da tabela config_celp", typeof(ITratarSincronizacaoCursosCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursosAlunosCelpSync, new ComandoRabbit("Tratamento de alunos do curso celp do sync no Google", typeof(ITratarSincronizacaoAlunosDoCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoCelpIncluir, new ComandoRabbit("Incluir cursos novos do Celp com Google", typeof(IIncluirCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, new ComandoRabbit("Inclusão do aluno no curso celp no Google", typeof(IIncluirAlunoCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, new ComandoRabbit("Inclusão do coordenador (funcionario) do curso celp no Google", typeof(IIncluirFuncionarioCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaAlunoCelpIncluir, new ComandoRabbit("Inclusão do aluno do celp no Google", typeof(IIncluirAlunoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar, new ComandoRabbit("Carregar codigos dos alunos para remoção de cursos celp", typeof(ITratarAlunosCursoUsuarioRemovidoCelpUseCase)));
        }

        private async Task TratarMensagem(BasicDeliverEventArgs ea)
        {
            var mensagem = Encoding.UTF8.GetString(ea.Body.Span);
            var rota = ea.RoutingKey;

            Console.WriteLine(string.Concat(rota, " - ", DateTime.Now.ToString("G")));

            if (comandos.ContainsKey(rota))
            {
                var mensagemRabbit = JsonConvert.DeserializeObject<MensagemRabbit>(mensagem);
                var comandoRabbit = comandos[rota];
                var tempoExecucao = Stopwatch.StartNew();
                var transacao = telemetriaOptions.Apm ? Agent.Tracer.StartTransaction(rota, "WorkerRabbitGCA") : null;

                try
                {
                    using var scope = serviceScopeFactory.CreateScope();
                    var casoDeUso = scope.ServiceProvider.GetService(comandoRabbit.TipoCasoUso);

                    metricReporter.RegistrarExecucao(casoDeUso.GetType().Name);

                    await servicoTelemetria.RegistrarAsync(async () =>
                        await ObterMetodo(comandoRabbit.TipoCasoUso, "Executar")
                            .InvokeAsync(casoDeUso, new object[] { mensagemRabbit }),
                        "WorkerRabbitGCA",
                        rota,
                        rota,
                        mensagem);

                    await canalRabbit.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (NegocioException nex)
                {
                    await canalRabbit.BasicRejectAsync(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(NegocioException));
                    await RegistrarErro(ea, mensagemRabbit, nex, LogNivel.Negocio);
                    transacao?.CaptureException(nex);
                }
                catch (ValidacaoException vex)
                {
                    await canalRabbit.BasicRejectAsync(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(ValidacaoException));
                    await RegistrarErro(ea, mensagemRabbit, vex, LogNivel.Negocio);
                    transacao?.CaptureException(vex);
                }
                catch (Exception ex)
                {
                    await canalRabbit.BasicRejectAsync(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, ex.GetType().Name);
                    await RegistrarErro(ea, mensagemRabbit, ex, LogNivel.Critico);
                    transacao?.CaptureException(ex);
                }
                finally
                {
                    transacao?.End();
                    tempoExecucao.Stop();
                    metricReporter.RegistrarTempoDeExecucao(comandoRabbit.TipoCasoUso.Name, tempoExecucao.Elapsed);
                }
            }
            else
                await canalRabbit.BasicRejectAsync(ea.DeliveryTag, false);
        }

        private async Task RegistrarErro(BasicDeliverEventArgs ea, MensagemRabbit mensagemRabbit, Exception ex, LogNivel nivel)
        {
            var mensagem = $"ERRO - {ea.RoutingKey} - {ex.Message}";

            await mediator.Send(new SalvarLogViaRabbitCommand(mensagem, nivel, LogContexto.WorkerRabbit, $"{mensagemRabbit?.Mensagem}", rastreamento: ex.StackTrace));
        }

        private Task RegistrarErro(string erro, Exception ex)
            => mediator.Send(new SalvarLogViaRabbitCommand(erro, LogNivel.Critico, LogContexto.WorkerRabbit, rastreamento: ex.StackTrace));

        private MethodInfo ObterMetodo(Type objType, string method)
        {
            var executar = objType.GetMethod(method);

            if (executar == null)
            {
                foreach (var itf in objType.GetInterfaces())
                {
                    executar = ObterMetodo(itf, method);
                    if (executar != null)
                        break;
                }
            }

            return executar;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            await InicializaConsumers(stoppingToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (canalRabbit != null && canalRabbit.IsOpen)
                await canalRabbit.CloseAsync(cancellationToken);

            if (conexaoRabbit != null && conexaoRabbit.IsOpen)
                await conexaoRabbit.CloseAsync(cancellationToken);
        }

        private async Task InicializaConsumers(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            if (conexaoRabbit == null || !conexaoRabbit.IsOpen)
            {
                var factory = new ConnectionFactory
                {
                    HostName = configuracaoRabbitOptions.HostName,
                    UserName = configuracaoRabbitOptions.UserName,
                    Password = configuracaoRabbitOptions.Password,
                    VirtualHost = configuracaoRabbitOptions.Virtualhost,
                    RequestedHeartbeat = TimeSpan.FromSeconds(30),
                };

                conexaoRabbit = await factory.CreateConnectionAsync(stoppingToken);
            }

            conexaoRabbit.CallbackExceptionAsync += ConexaoRabbit_CallbackException;
            conexaoRabbit.ConnectionShutdownAsync += ConexaoRabbit_ConnectionShutdown;

            canalRabbit = await conexaoRabbit.CreateChannelAsync(cancellationToken: stoppingToken);
            await canalRabbit.BasicQosAsync(0, consumoDeFilasOptions.LimiteDeMensagensPorExecucao, false, stoppingToken);

            await canalRabbit.ExchangeDeclareAsync(ExchangeRabbit.GoogleSync, "topic", true, false, cancellationToken: stoppingToken);
            await RegistrarFilasRabbitMQ.RegistrarFilas(canalRabbit, consumoDeFilasOptions);

            var consumer = new AsyncEventingBasicConsumer(canalRabbit);

            consumer.ReceivedAsync += async (ch, ea) =>
            {
                try
                {
                    await TratarMensagem(ea);
                }
                catch (Exception ex)
                {
                    await RegistrarErro($"Erro ao tratar mensagem - {ea.RoutingKey} - {ex.Message}", ex);
                    await canalRabbit.BasicRejectAsync(ea.DeliveryTag, false);
                }
            };

            await ConfigurarConsumoDeFilasRabbit(consumer);
        }

        private async Task ConexaoRabbit_CallbackException(object sender, CallbackExceptionEventArgs e)
        {
            await FecharConexoesRabbit();
            await InicializaConsumers(CancellationToken.None);
        }

        private async Task ConexaoRabbit_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            if (e.Initiator == ShutdownInitiator.Application)
                return;

            if (canalRabbit != null && canalRabbit.IsOpen)
                await canalRabbit.CloseAsync();

            if (conexaoRabbit != null && conexaoRabbit.IsOpen)
                await conexaoRabbit.CloseAsync();

            await InicializaConsumers(CancellationToken.None);
        }

        private async Task FecharConexoesRabbit()
        {
            if (canalRabbit != null && canalRabbit.IsOpen)
            {
                await canalRabbit.CloseAsync();
                await canalRabbit.DisposeAsync();
            }

            if (conexaoRabbit != null && conexaoRabbit.IsOpen)
            {
                await conexaoRabbit.CloseAsync();
                await conexaoRabbit.DisposeAsync();
            }
        }

        private async Task ConsumirFilas(AsyncEventingBasicConsumer consumer, params string[] filas)
        {
            foreach (var fila in filas)
                await canalRabbit.BasicConsumeAsync(fila, false, consumer);
        }

        private async Task ConfigurarConsumoDeFilasRabbit(AsyncEventingBasicConsumer consumer)
        {
            await ConfigurarConsumoDeFilasSync(consumer);
            await ConfigurarConsumoDeFilasGsa(consumer);
        }

        private async Task ConfigurarConsumoDeFilasSync(AsyncEventingBasicConsumer consumer)
        {
            if (consumoDeFilasOptions.ConsumirFilasSync)
            {
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGoogleSync,
                    RotasRabbit.FilaCursoSync,
                    RotasRabbit.FilaAlunoSync,
                    RotasRabbit.FilaProfessorSync,
                    RotasRabbit.FilaFuncionarioSync,
                    RotasRabbit.FilaCursoProfessorSync,
                    RotasRabbit.FilaProfessorCursoSync,
                    RotasRabbit.FilaProfessorCursoAtribuicaoSync,
                    RotasRabbit.FilaAlunoCursoSync,
                    RotasRabbit.FilaCursoAlunoSync,
                    RotasRabbit.FilaCursoGradeSync,
                    RotasRabbit.FilaFuncionarioCursoSync,
                    RotasRabbit.FilaCursoFuncionarioSync,
                    RotasRabbit.FilaFuncionarioIndiretoSync,
                    RotasRabbit.FilaAlunoErroSync,
                    RotasRabbit.FilaAlunoErroTratar,
                    RotasRabbit.FilaProfessorErroSync,
                    RotasRabbit.FilaProfessorErroTratar,
                    RotasRabbit.FilaFuncionarioErroSync,
                    RotasRabbit.FilaFuncionarioErroTratar,
                    RotasRabbit.FilaCursoErroSync,
                    RotasRabbit.FilaCursoErroTratar,
                    RotasRabbit.FilaUsuarioGoogleIdSync,
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar,
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar,
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar,

                    RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar,
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar,

                    RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar,

                    RotasRabbit.FilaGsaInativarUsuarioIniciar,
                    RotasRabbit.FilaGsaInativarUsuarioCarregar,
                    RotasRabbit.FilaGsaInativarUsuarioSync,

                    RotasRabbit.FilaGsaCursoUsuarioRemovidoSync,

                    RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar,
                    RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar,
                    RotasRabbit.FilaTratarProfessoresEFuncionariosInativar,
                    RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync,
                    RotasRabbit.FilaGsaInativarProfessorSync,

                    RotasRabbit.FilaCursoExtintoArquivarCarregar,
                    RotasRabbit.FilaCursoArquivarTratar,
                    RotasRabbit.FilaCursoArquivarSync,

                    RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar,
                    RotasRabbit.FilaCursoArquivarCarregar,

                    RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre,
                    RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente,

                    // Celp
                    RotasRabbit.FilaGsaCursosCelpSync,
                    RotasRabbit.FilaGsaCursosAlunosCelpSync,
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar,

                    RotasRabbit.FilaGsaCargaInicial);
            }

            if (consumoDeFilasOptions.ConsumirFilasDeInclusao)
            {
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaInativarUsuarioIncluir,
                    RotasRabbit.FilaCursoIncluir,
                    RotasRabbit.FilaAlunoIncluir,
                    RotasRabbit.FilaProfessorIncluir,
                    RotasRabbit.FilaFuncionarioIncluir,
                    RotasRabbit.FilaProfessorCursoIncluir,
                    RotasRabbit.FilaAlunoCursoIncluir,
                    RotasRabbit.FilaFuncionarioCursoIncluir,
                    RotasRabbit.FilaFuncionarioIndiretoIncluir,
                    RotasRabbit.FilaUsuarioGoogleIdAtualizar,
                    RotasRabbit.FilaProfessorCursoRemover,

                    RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso,
                    RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno,

                    RotasRabbit.FilaGsaCursoCelpIncluir,
                    RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir,
                    RotasRabbit.FilaGsaAlunoCelpIncluir,
                    RotasRabbit.FilaGsaCursoAlunoCelpIncluir,
                    RotasRabbit.FilaCursoAhRemover);
            }
        }

        private async Task ConfigurarConsumoDeFilasGsa(AsyncEventingBasicConsumer consumer)
        {
            await ConsumirFilas(consumer, RotasRabbit.FilaGsaGoogleSync);

            if (consumoDeFilasOptions.Gsa?.CargaCursoGsa == true)
                await ConsumirFilas(consumer, RotasRabbit.FilaGsaCursoCarregar);

            if (consumoDeFilasOptions.Gsa?.CargaUsuarioGsa == true)
                await ConsumirFilas(consumer, RotasRabbit.FilaGsaUsuarioCarregar);

            if (consumoDeFilasOptions.Gsa?.CargaCursoUsuarioGsa == true)
                await ConsumirFilas(consumer, RotasRabbit.FilaGsaCursoUsuarioCarregar);

            if (consumoDeFilasOptions.Gsa?.ProcessarCursoGsa == true)
            {
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaCursoIncluir,
                    RotasRabbit.FilaGsaCursoValidar);
            }

            if (consumoDeFilasOptions.Gsa?.ProcessarUsuarioGsa == true)
            {
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaUsuarioIncluir,
                    RotasRabbit.FilaGsaUsuarioValidar);
            }

            if (consumoDeFilasOptions.Gsa?.ProcessarCursoUsuarioGsa == true)
                await ConsumirFilas(consumer, RotasRabbit.FilaGsaCursoUsuarioIncluir);

            if (consumoDeFilasOptions.Gsa?.CargaMuralAvisosGsa == true)
            {
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaMuralAvisosCarregar,
                    RotasRabbit.FilaGsaMuralAvisosIncluir,
                    RotasRabbit.FilaGsaMuralAvisosTratar);
            }

            if (consumoDeFilasOptions.Gsa?.CargaAtividadesGsa == true)
            {
                // Atividades
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaAtividadesCarregar,
                    RotasRabbit.FilaGsaAtividadesIncluir,
                    RotasRabbit.FilaGsaAtividadesTratar);

                // Notas
                await ConsumirFilas(consumer,
                    RotasRabbit.FilaGsaNotasAtividadesCarregar,
                    RotasRabbit.FilaGsaNotasAtividadesTratar,
                    RotasRabbit.FilaGsaNotasAtividadesSync,
                    RotasRabbit.FilaGsaNotasAtividadesSyncErro);
            }
        }
    }
}