using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using System;

namespace SME.GoogleClassroom.Infra.Metricas
{
    public class MetricReporter : IMetricReporter
    {
        private readonly Counter contadorDeExecucao;
        private readonly Counter contadorDeErros;
        private readonly Histogram histogramaDeTempoDeExcucao;

        public MetricReporter()
        {
            contadorDeExecucao = Metrics.CreateCounter("sincronizacao_quantidade", "Quantidade de sincronizações realizadas.",
                new CounterConfiguration
                {
                    LabelNames = new[] { "caso_de_uso" }
                });

            contadorDeErros = Metrics.CreateCounter("sincronizacao_quantidade_erros", "Quantidade de erros nas sincronizações realizadas.",
                new CounterConfiguration
                {
                    LabelNames = new[] { "caso_de_uso", "erro" }
                });

            histogramaDeTempoDeExcucao = Metrics.CreateHistogram("sincronizacao_duracao_segundos",
                "Duração em segundos de uma sincronização", new HistogramConfiguration
                {
                    Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
                    LabelNames = new[] { "caso_de_uso" }
                });
        }

        public void RegistrarExecucao(string casoDeUso) => contadorDeExecucao.WithLabels(casoDeUso).Inc();

        public void RegistrarErro(string casoDeUso, string erro) => contadorDeErros.WithLabels(casoDeUso, erro).Inc();

        public void RegistrarTempoDeExecucao(string casoDeUso, TimeSpan elapsed)
        {
            histogramaDeTempoDeExcucao.WithLabels(casoDeUso).Observe(elapsed.TotalSeconds);
        }
    }

    public static class MetricReporterRegister
    {
        public static void UseMetricReporter(this IServiceCollection services)
        {
            services.AddSingleton<IMetricReporter, MetricReporter>();
        }
    }
}