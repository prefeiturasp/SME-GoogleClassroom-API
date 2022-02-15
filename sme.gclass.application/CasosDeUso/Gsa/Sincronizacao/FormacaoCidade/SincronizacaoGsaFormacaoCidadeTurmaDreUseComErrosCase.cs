using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaDreComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroTurmaRemoverCursoUsuarioDto>, ISincronizacaoGsaFormacaoCidadeTurmaDreComErrosUseCase
    {
        public SincronizacaoGsaFormacaoCidadeTurmaDreComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDreErro, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDre, configuration, mediator, registry)
        {
        }
    }
}