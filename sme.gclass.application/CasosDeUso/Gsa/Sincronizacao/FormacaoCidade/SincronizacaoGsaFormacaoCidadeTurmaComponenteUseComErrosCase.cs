using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroFormacaoCidadeTurmaComponenteDto>, ISincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase
    {
        public SincronizacaoGsaFormacaoCidadeTurmaComponenteComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, configuration, mediator, registry)
        {
        }
    }
}