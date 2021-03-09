using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class BaseIntegracaoGoogleClassroomHandler<TRequest> : IRequestHandler<TRequest, bool>
        where TRequest : IRequest<bool>
    {
        private readonly bool _deveExecutarIntegracao;
        private const int TempoParaSimularExecucaoEmAmbienteDeDesenvolvimento = 10000;

        public BaseIntegracaoGoogleClassroomHandler(VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!_deveExecutarIntegracao)
            {
                await Task.Delay(TempoParaSimularExecucaoEmAmbienteDeDesenvolvimento, cancellationToken);
                return true;
            }

            return await ExecutarAsync(request, cancellationToken);
        }

        protected abstract Task<bool> ExecutarAsync(TRequest request, CancellationToken cancellationToken);
    }
}