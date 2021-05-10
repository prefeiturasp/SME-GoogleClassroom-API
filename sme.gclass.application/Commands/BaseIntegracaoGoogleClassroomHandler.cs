using MediatR;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class BaseIntegracaoGoogleClassroomHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IMetricReporter metricReporter;

        public BaseIntegracaoGoogleClassroomHandler(IMetricReporter metricReporter)
        {
            this.metricReporter = metricReporter;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected void RegistraRequisicaoGoogleClassroom() => metricReporter.RegistraRequisicaoGsa();
    }
}