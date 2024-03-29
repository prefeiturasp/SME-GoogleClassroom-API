﻿using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class EnvioDeDadosIntegracaoGoogleClassroomHandler<TRequest> : BaseIntegracaoGoogleClassroomHandler<TRequest, bool>
        where TRequest : IRequest<bool>
    {
        private readonly bool _deveExecutarIntegracao;
        private const int TempoParaSimularExecucaoEmAmbienteDeDesenvolvimento = 1000;

        protected EnvioDeDadosIntegracaoGoogleClassroomHandler(VariaveisGlobaisOptions variaveisGlobaisOptions)
            :base()
        {
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public override async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!_deveExecutarIntegracao)
            {
                await ExecutarQuandoNaoHabilitarIntegracaoAsync(request, cancellationToken);
                return true;
            }

            RegistraRequisicaoGoogleClassroom();
            return await ExecutarAsync(request, cancellationToken);
        }

        protected abstract Task<bool> ExecutarAsync(TRequest request, CancellationToken cancellationToken);

        protected virtual Task ExecutarQuandoNaoHabilitarIntegracaoAsync(TRequest request, CancellationToken cancellationToken)
            => Task.Delay(TempoParaSimularExecucaoEmAmbienteDeDesenvolvimento, cancellationToken);
    }
}