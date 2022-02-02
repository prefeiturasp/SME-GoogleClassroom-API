using Elastic.Apm;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra
{
    public class ServicoTelemetria : IServicoTelemetria
    {
        private readonly TelemetriaOptions telemetriaOptions;

        public ServicoTelemetria(TelemetriaOptions telemetriaOptions)
        {
            this.telemetriaOptions = telemetriaOptions ?? throw new ArgumentNullException(nameof(telemetriaOptions));
        }

        public async Task<dynamic> RegistrarComRetornoAsync<T>(Func<Task<object>> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
        {
            dynamic result = default;

            if (telemetriaOptions.Apm)
            {
                var transactionElk = Agent.Tracer.CurrentTransaction;

                await transactionElk.CaptureSpan(telemetriaNome, acaoNome, async (span) =>
                {
                    span.SetLabel(telemetriaNome, telemetriaValor);
                    result = (await acao()) as dynamic;
                });
            }
            else
            {
                result = await acao() as dynamic;
            }

            return result;
        }

        public dynamic RegistrarComRetorno<T>(Func<object> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
        {
            dynamic result = default;

            if (telemetriaOptions.Apm)
            {
                var transactionElk = Agent.Tracer.CurrentTransaction;

                transactionElk.CaptureSpan(telemetriaNome, acaoNome, (span) =>
                {
                    span.SetLabel(telemetriaNome, telemetriaValor);
                    result = acao();
                });
            }
            else
            {
                result = acao();
            }

            return result;
        }

        public void Registrar(Action acao, string acaoNome, string telemetriaNome, string telemetriaValor)
        {
            if (telemetriaOptions.Apm)
            {
                var transactionElk = Agent.Tracer.CurrentTransaction;

                transactionElk.CaptureSpan(telemetriaNome, acaoNome, (span) =>
                {
                    span.SetLabel(telemetriaNome, telemetriaValor);
                    acao();
                });
            }
            else
            {
                acao();
            }
        }

        public async Task RegistrarAsync(Func<Task> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
        {
            if (telemetriaOptions.Apm)
            {
                var transactionElk = Agent.Tracer.CurrentTransaction;

                await transactionElk.CaptureSpan(telemetriaNome, acaoNome, async (span) =>
                {
                    span.SetLabel(telemetriaNome, telemetriaValor);
                    await acao();
                });
            }
            else
            {
                await acao();
            }
        }

    }
}
