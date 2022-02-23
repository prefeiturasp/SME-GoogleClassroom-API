using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroFormacaoCidadeTurmaDto>, ISincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase
    {
        public SincronizacaoGsaFormacaoCidadeTurmaSmeDreComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, configuration, mediator, registry)
        {
        }
    }
}