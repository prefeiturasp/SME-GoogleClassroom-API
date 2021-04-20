using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleCursoUseCase : IIniciarSyncGoogleCursoUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? turmaId, long? componenteCurricularId)
        {
            var command = new IniciarSyncGoogleCursoCommand(turmaId, componenteCurricularId);
            return await mediator.Send(command);
        }
    }
}