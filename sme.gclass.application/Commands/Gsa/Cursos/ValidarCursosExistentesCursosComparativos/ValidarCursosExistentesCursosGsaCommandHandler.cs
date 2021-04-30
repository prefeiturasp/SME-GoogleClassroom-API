using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarCursosExistentesCursosGsaCommandHandler : AsyncRequestHandler<ValidarCursosExistentesCursosGsaCommand>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public ValidarCursosExistentesCursosGsaCommandHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo;
        }

        protected override async Task Handle(ValidarCursosExistentesCursosGsaCommand request, CancellationToken cancellationToken)
            => await repositorioCursoComparativo.ValidarCursosExistentesCursosComparativosAsync();
    }
}