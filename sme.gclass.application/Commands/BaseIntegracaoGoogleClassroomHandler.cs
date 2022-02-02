using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class BaseIntegracaoGoogleClassroomHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public BaseIntegracaoGoogleClassroomHandler()
        {
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected void RegistraRequisicaoGoogleClassroom()
        {
            return; // metricReporter.RegistraRequisicaoGsa(); REMOVIDO IMetricReporter
        } 
    }
}