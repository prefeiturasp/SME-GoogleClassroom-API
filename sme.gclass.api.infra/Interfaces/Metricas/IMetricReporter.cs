using System;

namespace SME.GoogleClassroom.Infra.Interfaces.Metricas
{
    public interface IMetricReporter
    {
        void RegistrarExecucao(string casoDeUso);

        void RegistrarErro(string casoDeUso, string erro);

        void RegistrarTempoDeExecucao(string casoDeUso, TimeSpan elapsed);

        void RegistraRequisicaoGsa();
    }
}