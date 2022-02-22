using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroFormacaoCidadeTurmaCursoDto>, ISincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase
    {
        public SincronizacaoGsaFormacaoCidadeTurmaCursoComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, configuration, mediator, registry)
        {
        }
    }
}