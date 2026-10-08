using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarCursosExistentesCursosGsaCommandHandler : IRequestHandler<ValidarCursosExistentesCursosGsaCommand>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public ValidarCursosExistentesCursosGsaCommandHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo;
        }

        public async Task Handle(ValidarCursosExistentesCursosGsaCommand request, CancellationToken cancellationToken)
            => await repositorioCursoComparativo.ValidarCursosExistentesCursosComparativosAsync();
    }
}