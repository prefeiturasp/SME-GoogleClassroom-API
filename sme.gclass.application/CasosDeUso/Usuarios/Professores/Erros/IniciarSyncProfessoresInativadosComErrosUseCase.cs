using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncProfessoresInativadosComErrosUseCase: AbstractTratarFilaErrosUseCase<FiltroTurmaRemoverCursoUsuarioDto>, IIniciarSyncProfessoresInativadosComErrosUseCase
    {
        public IniciarSyncProfessoresInativadosComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
           : base(RotasRabbit.FilaGsaInativarProfessorErroTratar, RotasRabbit.FilaGsaInativarProfessorErroTratar, configuration, mediator, registry)
        {
        }
    }
}
