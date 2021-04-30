using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarCursosExistentesCursosComparativosCommandHandler : AsyncRequestHandler<ValidarCursosExistentesCursosComparativosCommand>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public ValidarCursosExistentesCursosComparativosCommandHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo;
        }

        protected override async Task Handle(ValidarCursosExistentesCursosComparativosCommand request, CancellationToken cancellationToken)
            => await repositorioCursoComparativo.ValidarCursosExistentesCursosComparativosAsync();
    }
}