using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{

    public class IniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroTurmaRemoverCursoUsuarioDto>, IIniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase
    {
        public IniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro, RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, configuration, mediator, registry)
        {
        }
    }
}