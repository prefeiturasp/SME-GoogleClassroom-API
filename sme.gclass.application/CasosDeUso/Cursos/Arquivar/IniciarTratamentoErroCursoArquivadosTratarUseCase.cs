using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarTratamentoErroCursoArquivadosTratarUseCase : AbstractTratarFilaErrosUseCase<ArquivarTurmaExtintaDto>, IIniciarTratamentoErroCursoArquivadosTratarUseCase
    {
        public IniciarTratamentoErroCursoArquivadosTratarUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaCursoExtintoArquivarTratarErro, RotasRabbit.FilaCursoExtintoArquivarTratar, configuration, mediator, registry)
        {
        }
    }
}
