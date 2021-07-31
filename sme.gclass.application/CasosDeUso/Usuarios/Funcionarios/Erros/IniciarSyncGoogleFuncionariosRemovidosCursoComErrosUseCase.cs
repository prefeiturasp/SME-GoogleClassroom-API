using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroTurmaRemoverCursoUsuarioDto>, IIniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase
    {
        public IniciarSyncGoogleFuncionariosRemovidosCursoComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro, RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, configuration, mediator, registry)
        {
        }
    }
}
