using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarTratamentoErroCursoArquivadosSyncUseCase : AbstractTratarFilaErrosUseCase<ArquivarCursoDto>, IIniciarTratamentoErroCursoArquivadosSyncUseCase
    {
        public IniciarTratamentoErroCursoArquivadosSyncUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaCursoArquivarSyncErro, RotasRabbit.FilaCursoArquivarSync, configuration, mediator, registry)
        {
        }
    }
}
