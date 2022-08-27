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
        private IModel canalRabbit;
        private IConnection conexaoRabbit;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IMetricReporter metricReporter;
        private readonly IServicoTelemetria servicoTelemetria;
        private readonly ConsumoDeFilasOptions consumoDeFilasOptions;
        private readonly ConfiguracaoRabbitOptions configuracaoRabbitOptions;
        private readonly TelemetriaOptions telemetriaOptions;
        private readonly IMediator mediator;

        /// <summary>
        /// configuração da lista de tipos para a fila do rabbit instanciar, seguindo a ordem de propriedades:
        /// rota do rabbit, usaMediatr?, tipo
        /// </summary>
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

            //Notas
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesCarregar, new ComandoRabbit("Carrega atividades para importacao de notas", typeof(ICarregarAtividadesParaSincronizarNotasUseCase)));
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesTratar, new ComandoRabbit("Tratar carga de notas das atividades para importacao", typeof(ITratarImportacaoDeNotasDaAtividadeUseCase)));
            comandos.Add(RotasRabbit.FilaGsaNotasAtividadesSync, new ComandoRabbit("Executar importação de notas da atividade", typeof(IExecutarImportacaoDeNotasDaAtividadeUseCase)));

           comandos.Add(RotasRabbit.FilaGsaNotasAtividadesSyncErro, new ComandoRabbit("Gravar erros na importação das notas", typeof(IImportarNotasGsaProcessarErroUseCase)));

            //Carga Inicial
            comandos.Add(RotasRabbit.FilaGsaCargaInicial, new ComandoRabbit("Carga inicial executada manualmente", typeof(ITrataSyncManualGoogleGeralUseCase)));
            comandos.Add(RotasRabbit.FilaCursoAhRemover, new ComandoRabbit("Remover curso", typeof(IRemoverCursoGoogleClassroomUseCase)));

            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA por SME ou DRE", typeof(ISincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA por Componente", typeof(ISincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA - criação do Curso", typeof(ISincronizacaoGsaFormacaoCidadeTurmaCursoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, new ComandoRabbit("Sincroniza as turmas de formação cidade no GSA - atribuição de Aluno", typeof(ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase)));
            
            //Celp
            comandos.Add(RotasRabbit.FilaGsaCursosCelpSync, new ComandoRabbit("Sincroniza os cursos do Celp no Google com base na configuração da tabela config_celp", typeof(ITratarSincronizacaoCursosCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursosAlunosCelpSync, new ComandoRabbit("Tratamento de alunos do curso celp do sync no Google", typeof(ITratarSincronizacaoAlunosDoCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoCelpIncluir, new ComandoRabbit("Incluir cursos novos do Celp com Google", typeof(IIncluirCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, new ComandoRabbit("Inclusão do aluno no curso celp no Google", typeof(IIncluirAlunoCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, new ComandoRabbit("Inclusão do coordenador (funcionario) do curso celp no Google", typeof(IIncluirFuncionarioCursoCelpGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaGsaAlunoCelpIncluir, new ComandoRabbit("Inclusão do aluno do celp no Google", typeof(IIncluirAlunoCelpGoogleUseCase)));
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

                    canalRabbit.BasicAck(ea.DeliveryTag, false);
                }
                catch (NegocioException nex)
                {
                    canalRabbit.BasicReject(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(NegocioException));
                    RegistrarErro(ea, mensagemRabbit, nex, LogNivel.Negocio);
                    transacao.CaptureException(nex);
                }
                catch (ValidacaoException vex)
                {
                    canalRabbit.BasicReject(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(ValidacaoException));
                    RegistrarErro(ea, mensagemRabbit, vex, LogNivel.Negocio);
                    transacao.CaptureException(vex);
                }
                catch (Exception ex)
                {
                    canalRabbit.BasicReject(ea.DeliveryTag, false);
                    metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, ex.GetType().Name);
                    RegistrarErro(ea, mensagemRabbit, ex, LogNivel.Critico);
                    transacao.CaptureException(ex);
                }
                finally
                {
                    transacao?.End();
                    tempoExecucao.Stop();
                    metricReporter.RegistrarTempoDeExecucao(comandoRabbit.TipoCasoUso.Name, tempoExecucao.Elapsed);
                }
            }
            else
                canalRabbit.BasicReject(ea.DeliveryTag, false);
        }

        private async void RegistrarErro(BasicDeliverEventArgs ea, MensagemRabbit mensagemRabbit, Exception ex, LogNivel nivel)
        {
            var mensagem = $"ERRO - {ea.RoutingKey} - {ex.Message}";

            await mediator.Send(new SalvarLogViaRabbitCommand(mensagem, nivel, LogContexto.WorkerRabbit, $"{mensagemRabbit?.Mensagem}", rastreamento: ex.StackTrace));
        }

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

        public Task StopAsync(CancellationToken cancellationToken)
        {
            canalRabbit.Close();
            conexaoRabbit.Close();
            return Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            await InicializaConsumers(stoppingToken);         
        }

        private void ConfigurarConsumoDeFilasRabbit(EventingBasicConsumer consumer)
        {
            ConfigurarConsumoDeFilasSync(consumer);
            ConfigurarConsumoDeFilasGsa(consumer);
        }

        private void ConexaoRabbit_CallbackException(object sender, CallbackExceptionEventArgs e)
        {
            FecharConexoesRabbit();

            _ = Task.FromResult(InicializaConsumers(new CancellationToken())).Result;
        }

        private void FecharConexoesRabbit()
        {
            if (canalRabbit.IsOpen)
            {
                canalRabbit.Close();
                canalRabbit.Dispose();
            }

            if (conexaoRabbit.IsOpen)
            {
                conexaoRabbit.Close();
                conexaoRabbit.Dispose();
            }
        }
        private void ConexaoRabbit_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            if (canalRabbit.IsOpen)
                canalRabbit.Close();
            if (conexaoRabbit.IsOpen)
                conexaoRabbit.Close();
            _ = Task.FromResult(InicializaConsumers(new CancellationToken())).Result;
        }
        private Task InicializaConsumers(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var factory = new ConnectionFactory
            {
                HostName = configuracaoRabbitOptions.HostName,
                UserName = configuracaoRabbitOptions.UserName,
                Password = configuracaoRabbitOptions.Password,
                VirtualHost = configuracaoRabbitOptions.Virtualhost,
                RequestedHeartbeat = TimeSpan.FromSeconds(30),
            };

            conexaoRabbit = factory.CreateConnection();
            conexaoRabbit.CallbackException += ConexaoRabbit_CallbackException;
            conexaoRabbit.ConnectionShutdown += ConexaoRabbit_ConnectionShutdown;


            canalRabbit = conexaoRabbit.CreateModel();

            canalRabbit.BasicQos(0, 10, false);

            canalRabbit = conexaoRabbit.CreateModel();
            canalRabbit.BasicQos(0, consumoDeFilasOptions.LimiteDeMensagensPorExecucao, false);

            canalRabbit.ExchangeDeclare(ExchangeRabbit.GoogleSync, "topic", true, false);
            RegistrarFilasRabbitMQ.RegistrarFilas(canalRabbit, consumoDeFilasOptions);

            var consumer = new EventingBasicConsumer(canalRabbit);

            consumer.Received += async (ch, ea) =>
            {
                try
                {
                    await TratarMensagem(ea);
                }
                catch (Exception ex)
                {
                    await RegistrarErro($"Erro ao tratar mensagem - {ea.RoutingKey} - {ex.Message}", ex);
                    canalRabbit.BasicReject(ea.DeliveryTag, false);
                }
            };

            ConfigurarConsumoDeFilasRabbit(consumer);

            return Task.CompletedTask;
        }

        private Task RegistrarErro(string erro, Exception ex)
            => mediator.Send(new SalvarLogViaRabbitCommand(erro, LogNivel.Critico, LogContexto.WorkerRabbit, rastreamento: ex.StackTrace));

        private void ConfigurarConsumoDeFilasSync(EventingBasicConsumer consumer)
        {
            if (consumoDeFilasOptions.ConsumirFilasSync)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGoogleSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoProfessorSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoAtribuicaoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoAlunoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoGradeSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoFuncionarioSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioIndiretoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoErroSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoErroTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorErroSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorErroTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioErroSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioErroTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoErroSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoErroTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaUsuarioGoogleIdSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarUsuarioIniciar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarUsuarioCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarUsuarioSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarUsuarioTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarUsuarioIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaTratarProfessoresEFuncionariosInativar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaInativarProfessorSync, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaCursoExtintoArquivarCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoArquivarTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoArquivarSync, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoArquivarCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoAhRemover, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, false, consumer);
                
                //Celp
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursosCelpSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoCelpIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursosAlunosCelpSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaAlunoCelpIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, false, consumer);
            }

            if (consumoDeFilasOptions.ConsumirFilasDeInclusao)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioIndiretoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaUsuarioGoogleIdAtualizar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoRemover, false, consumer);

                canalRabbit.BasicConsume(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, false, consumer);
            }
        }

        private void ConfigurarConsumoDeFilasGsa(EventingBasicConsumer consumer)
        {
            canalRabbit.BasicConsume(RotasRabbit.FilaGsaGoogleSync, false, consumer);

            if (consumoDeFilasOptions.Gsa.CargaCursoGsa)
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoCarregar, false, consumer);

            if (consumoDeFilasOptions.Gsa.CargaUsuarioGsa)
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaUsuarioCarregar, false, consumer);

            if (consumoDeFilasOptions.Gsa.CargaCursoUsuarioGsa)
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioCarregar, false, consumer);

            if (consumoDeFilasOptions.Gsa.ProcessarCursoGsa)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoValidar, false, consumer);
            }

            if (consumoDeFilasOptions.Gsa.ProcessarUsuarioGsa)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaUsuarioIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaUsuarioValidar, false, consumer);
            }

            if (consumoDeFilasOptions.Gsa.ProcessarCursoUsuarioGsa)
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioIncluir, false, consumer);

            if (consumoDeFilasOptions.Gsa.CargaMuralAvisosGsa)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaMuralAvisosCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaMuralAvisosIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaMuralAvisosTratar, false, consumer);
            }

            if (consumoDeFilasOptions.Gsa.CargaAtividadesGsa)
            {
                // Atividades
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaAtividadesCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaAtividadesIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaAtividadesTratar, false, consumer);

                // Notas
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaNotasAtividadesCarregar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaNotasAtividadesTratar, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaNotasAtividadesSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaNotasAtividadesSyncErro, false, consumer);
            }
            
            if (consumoDeFilasOptions.Gsa.CargaInicial)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCargaInicial, false, consumer);
            }
        }
    }
}
