using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleCursoCommandHandler : IRequestHandler<IniciarSyncGoogleCursoCommand, bool>
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleCursoCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Handle(IniciarSyncGoogleCursoCommand request, CancellationToken cancellationToken)
        {
            var dto = new IniciarSyncGoogleCursoDto(request.TurmaId, request.ComponenteCurricularId);

            var publicarSyncFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, dto));
            if (!publicarSyncFuncionario)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de cursos.");
            }

            return publicarSyncFuncionario;
        }
    }
}