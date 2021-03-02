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

        /// <summary>
        /// configuração da lista de tipos para a fila do rabbit instanciar, seguindo a ordem de propriedades:
        /// rota do rabbit, usaMediatr?, tipo
        /// </summary>
        private readonly Dictionary<string, ComandoRabbit> comandos;

        public WorkerRabbitMQ(IConnection conexaoRabbit, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, IMetricReporter metricReporter)
        {
            sentryDSN = configuration.GetValue<string>("Sentry:DSN");
            this.conexaoRabbit = conexaoRabbit ?? throw new ArgumentNullException(nameof(conexaoRabbit));
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            this.metricReporter = metricReporter;
            canalRabbit = conexaoRabbit.CreateModel();

            canalRabbit.ExchangeDeclare(RotasRabbit.ExchangeGoogleSync, "topic", true, false);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGoogleSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaGoogleSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaGoogleSync);

            RegistrarFilasCurso();
            RegistrarFilasFuncionario();
            RegistrarFilasProfessor();

            comandos = new Dictionary<string, ComandoRabbit>();
            RegistrarUseCases();
        }

        private void RegistrarFilasCurso()
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuarioSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuarioSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaUsuarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoIncluir);
        }

        private void RegistrarFilasFuncionario()
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioIncluir);
        }

        private void RegistrarFilasProfessor()
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorIncluir);
        }

        private void RegistrarUseCases()
        {
            comandos.Add(RotasRabbit.FilaGoogleSync, new ComandoRabbit("Tratamento geral do sync com google", typeof(ITrataSyncGoogleGeralUseCase)));
            comandos.Add(RotasRabbit.FilaCursoIncluir, new ComandoRabbit("Incluir cursos novos no google", typeof(IIncluirCursoUseCase)));

            comandos.Add(RotasRabbit.FilaUsuarioSync, new ComandoRabbit("Tratamento de usuário do sync com google", typeof(ITrataSyncGoogleUsuarioUseCase)));
            comandos.Add(RotasRabbit.FilaCursoSync, new ComandoRabbit("Incluir cursos novos no google", typeof(ITrataSyncGoogleCursoUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioSync, new ComandoRabbit("Tratamento de funcionários do sync com Google", typeof(ITrataSyncGoogleFuncionarioUseCase)));
            comandos.Add(RotasRabbit.FilaFuncionarioIncluir, new ComandoRabbit("Incluir funcionários novos no Google", typeof(IInserirFuncionarioGoogleUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorSync, new ComandoRabbit("Tratamento de professores do sync com Google", typeof(ITrataSyncGoogleProfessorUseCase)));
            comandos.Add(RotasRabbit.FilaProfessorIncluir, new ComandoRabbit("Incluir professores novos no Google", typeof(IInserirProfessorGoogleUseCase)));
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

            canalRabbit.BasicConsume(RotasRabbit.FilaGoogleSync, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaCursoIncluir, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaCursoSync, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioSync, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaFuncionarioIncluir, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaProfessorSync, false, consumer);
            canalRabbit.BasicConsume(RotasRabbit.FilaProfessorIncluir, false, consumer);

            return Task.CompletedTask;
        }
    }
}
