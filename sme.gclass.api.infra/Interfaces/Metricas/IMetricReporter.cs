using Prometheus;
using System;

namespace SME.GoogleClassroom.Infra.Interfaces.Metricas
{
    public interface IMetricReporter
    {
        void RegistrarExecucao(string casoDeUso);

        void RegistrarTempoDeExecucao(string casoDeUso, TimeSpan elapsed);      
    }
}