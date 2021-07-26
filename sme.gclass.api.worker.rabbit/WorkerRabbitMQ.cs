using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sentry;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public class WorkerRabbitMQ : IHostedService
    {
        private readonly IModel canalRabbit;
        private readonly string sentryDSN;
        private readonly IConnection conexaoRabbit;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IMetricReporter metricReporter;
        private readonly ConsumoDeFilasOptions consumoDeFilasOptions;

        /// <summary>
        /// configuração da lista de tipos para a fila do rabbit instanciar, seguindo a ordem de propriedades:
        /// rota do rabbit, usaMediatr?, tipo
        /// </summary>
        private readonly Dictionary<string, ComandoRabbit> comandos;

        public WorkerRabbitMQ(IConnection conexaoRabbit, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, IMetricReporter metricReporter, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            sentryDSN = configuration.GetValue<string>("Sentry:DSN");
            this.conexaoRabbit = conexaoRabbit ?? throw new ArgumentNullException(nameof(conexaoRabbit));
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            this.metricReporter = metricReporter;
            this.consumoDeFilasOptions = consumoDeFilasOptions;
            canalRabbit = conexaoRabbit.CreateModel();
            canalRabbit.BasicQos(0, consumoDeFilasOptions.LimiteDeMensagensPorExecucao, false);

            canalRabbit.ExchangeDeclare(ExchangeRabbit.GoogleSync, "topic", true, false);
            RegistrarFilasRabbitMQ.RegistrarFilas(canalRabbit, consumoDeFilasOptions);

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
            comandos.Add(RotasRabbit.FilaProfessorCursoIncluir, new ComandoRabbit("Atribuir professor ao curso no google", typeof(IInserirProfessorCursoGoogleUseCase)));
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

            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, new ComandoRabbit("Carregar turmas dos usuários para remoção de cursos", typeof(IRealizarCargaTurmasCursoUsuarioRemovidoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, new ComandoRabbit("Carregar turmas dos usuários para remoção de cursos", typeof(ITratarTurmaCursoUsuarioRemovidoUseCase)));
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, new ComandoRabbit("Carregar codigos dos alunos para remoção de cursos", typeof(ITratarAlunosCursoUsuarioRemovidoUseCase)));
            
            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, new ComandoRabbit("Carregar codigos dos professores para remoção de cursos", typeof(ITratarProfessoresRemovidosCursosUseCase)));

            comandos.Add(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, new ComandoRabbit("Sincroniza curso do usuário GSA e exclui registro", typeof(ISincronizarRemocaoUsuarioCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosCarregar, new ComandoRabbit("Sincroniza os avisos do mural GSA a serem carregados na base", typeof(IRealizarCargaMuralAvisosGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosTratar, new ComandoRabbit("Tratar os avisos do mural GSA a serem carregados na base", typeof(ITratarImportacaoMuralAvisosCursoGsaUseCase)));
            comandos.Add(RotasRabbit.FilaGsaMuralAvisosIncluir, new ComandoRabbit("Incluir os avisos do mural GSA a serem carregados na base", typeof(IImportarMuralAvisosCursoGsaUseCase)));
        }

        private async Task TratarMensagem(BasicDeliverEventArgs ea)
        {
            var mensagem = Encoding.UTF8.GetString(ea.Body.Span);
            var rota = ea.RoutingKey;
            if (comandos.ContainsKey(rota))
            {
                using (SentrySdk.Init(sentryDSN))
                {
                    var mensagemRabbit = JsonConvert.DeserializeObject<MensagemRabbit>(mensagem);
                    //SentrySdk.AddBreadcrumb($"Dados: {mensagemRabbit.Mensagem}");
                    Console.WriteLine($"Dados: {mensagemRabbit.Mensagem}");
                    var comandoRabbit = comandos[rota];
                    var tempoExecucao = System.Diagnostics.Stopwatch.StartNew();
                    try
                    {
                        using var scope = serviceScopeFactory.CreateScope();
                        var casoDeUso = scope.ServiceProvider.GetService(comandoRabbit.TipoCasoUso);

                        metricReporter.RegistrarExecucao(casoDeUso.GetType().Name);
                        await ObterMetodo(comandoRabbit.TipoCasoUso, "Executar").InvokeAsync(casoDeUso, new object[] { mensagemRabbit });

                        canalRabbit.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (NegocioException nex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(NegocioException));
                        SentrySdk.AddBreadcrumb($"Erros: {nex.Message}");
                        RegistrarSentry(ea, mensagemRabbit, nex);
                        Console.Write($"Erros de Negocio: {nex.Message}");
                    }
                    catch (ValidacaoException vex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, nameof(ValidacaoException));
                        SentrySdk.AddBreadcrumb($"Erros: {JsonConvert.SerializeObject(vex.Mensagens())}");
                        RegistrarSentry(ea, mensagemRabbit, vex);
                        Console.Write($"Erros de Validação: {vex.Message}");
                    }
                    catch (Exception ex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        metricReporter.RegistrarErro(comandoRabbit.TipoCasoUso.Name, ex.GetType().Name);
                        SentrySdk.AddBreadcrumb($"Erros: {ex.Message}");
                        RegistrarSentry(ea, mensagemRabbit, ex);
                        Console.Write($"Erros: {ex.Message}");
                    }
                    finally
                    {
                        tempoExecucao.Stop();
                        metricReporter.RegistrarTempoDeExecucao(comandoRabbit.TipoCasoUso.Name, tempoExecucao.Elapsed);
                    }
                }
            }
            else
                canalRabbit.BasicReject(ea.DeliveryTag, false);
        }

        private void RegistrarSentry(BasicDeliverEventArgs ea, MensagemRabbit mensagemRabbit, Exception ex)
        {
            SentrySdk.CaptureMessage($"ERRO - {ea.RoutingKey} - {mensagemRabbit?.Mensagem}", SentryLevel.Error);
            SentrySdk.CaptureException(ex);
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

        public Task StartAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(canalRabbit);
            consumer.Received += async (ch, ea) =>
            {
                try
                {
                    await TratarMensagem(ea);
                }
                catch (Exception)
                {
                    //TODO: Tratar alguma exeção não tratada e continuar o consumer do rabbit
                }
            };

            ConfigurarConsumoDeFilasRabbit(consumer);
            return Task.CompletedTask;
        }

        private void ConfigurarConsumoDeFilasRabbit(EventingBasicConsumer consumer)
        {
            ConfigurarConsumoDeFilasSync(consumer);
            ConfigurarConsumoDeFilasGsa(consumer);
        }

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
                canalRabbit.BasicConsume(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, false, consumer);
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
        }
    }
}
