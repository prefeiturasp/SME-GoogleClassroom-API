using MediatR;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoUseCase : IAtribuirDonoCursoUseCase
    {
        private readonly IMediator mediator;

        public AtribuirDonoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(string email, long turmaId, long componenteCurricularId)
        {
            return await mediator.Send(new AtribuirDonoCursoGoogleCommand(email, turmaId, componenteCurricularId));
        }
    }
}
