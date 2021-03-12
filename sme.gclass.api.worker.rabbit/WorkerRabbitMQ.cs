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

            canalRabbit.ExchangeDeclare(RotasRabbit.ExchangeGoogleSync, "topic", true, false);
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
            comandos.Add(RotasRabbit.FilaFuncionarioCursoSync, new ComandoRabbit("Tratamento de cursos do funcionário do sync com Google", typeof(ITrataSyncGoogleCursosDoFuncionarioUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioCursoIncluir, new ComandoRabbit("Atribuir funcionario ao curso no google", typeof(IInserirFuncionarioCursoGoogleUseCase)));
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
                    SentrySdk.AddBreadcrumb($"Dados: {mensagemRabbit.Mensagem}");
                    var comandoRabbit = comandos[rota];
                    try
                    {
                        using var scope = serviceScopeFactory.CreateScope();

                        var dataHoraInicio = DateTime.Now;
                        //SentrySdk.CaptureMessage($"{mensagemRabbit.UsuarioLogadoRF} - {mensagemRabbit.CodigoCorrelacao.ToString().Substring(0, 3)} - EXECUTANDO - {ea.RoutingKey} - {DateTime.Now:dd/MM/yyyy HH:mm:ss}", SentryLevel.Debug);
                        var casoDeUso = scope.ServiceProvider.GetService(comandoRabbit.TipoCasoUso);

                        metricReporter.RegistrarExecucao(casoDeUso.GetType().Name);
                        await ObterMetodo(comandoRabbit.TipoCasoUso, "Executar").InvokeAsync(casoDeUso, new object[] { mensagemRabbit });

                        //SentrySdk.CaptureMessage($"{mensagemRabbit.UsuarioLogadoRF} - {mensagemRabbit.CodigoCorrelacao.ToString().Substring(0, 3)} - SUCESSO - {ea.RoutingKey}", SentryLevel.Info);
                        canalRabbit.BasicAck(ea.DeliveryTag, false);

                        var dataHoraFim = DateTime.Now;
                        var tempoDeExecucao = dataHoraFim.Subtract(dataHoraInicio);
                        metricReporter.RegistrarTempoDeExecucao(casoDeUso.GetType().Name, mensagemRabbit.Mensagem, dataHoraInicio, dataHoraFim, tempoDeExecucao);

                    }
                    catch (NegocioException nex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        SentrySdk.AddBreadcrumb($"Erros: {nex.Message}");
                        SentrySdk.CaptureException(nex);
                        RegistrarSentry(ea, mensagemRabbit, nex);
                    }
                    catch (ValidacaoException vex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        SentrySdk.AddBreadcrumb($"Erros: {JsonConvert.SerializeObject(vex.Mensagens())}");
                        SentrySdk.CaptureException(vex);
                        RegistrarSentry(ea, mensagemRabbit, vex);
                    }
                    catch (Exception ex)
                    {
                        canalRabbit.BasicReject(ea.DeliveryTag, false);
                        SentrySdk.AddBreadcrumb($"Erros: {ex.Message}");
                        SentrySdk.CaptureException(ex);
                        RegistrarSentry(ea, mensagemRabbit, ex);
                    }
                }
            }
            else
                canalRabbit.BasicReject(ea.DeliveryTag, false);
        }

        private void RegistrarSentry(BasicDeliverEventArgs ea, MensagemRabbit mensagemRabbit, Exception ex)
        {
            SentrySdk.CaptureMessage($"ERRO - {ea.RoutingKey}", SentryLevel.Error);
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

            if(consumoDeFilasOptions.ConsumirFilasSync)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaGoogleSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoProfessorSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoAtribuicaoSync, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioCursoSync, false, consumer);
            }

            if(consumoDeFilasOptions.ConsumirFilasDeInclusao)
            {
                canalRabbit.BasicConsume(RotasRabbit.FilaCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaAlunoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaProfessorCursoIncluir, false, consumer);
                canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioCursoIncluir, false, consumer);
            }

            return Task.CompletedTask;
        }
    }
}
