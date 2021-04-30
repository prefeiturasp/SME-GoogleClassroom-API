using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarUsuariosExistentesCursosGsaCommandHandler : AsyncRequestHandler<ValidarUsuariosExistentesCursosGsaCommand>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioComparativo;

        public ValidarUsuariosExistentesCursosGsaCommandHandler(IRepositorioUsuarioGsa repositorioUsuarioComparativo)
        {
            this.repositorioUsuarioComparativo = repositorioUsuarioComparativo ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioComparativo));
        }

        protected override async Task Handle(ValidarUsuariosExistentesCursosGsaCommand request, CancellationToken cancellationToken) 
            => await repositorioUsuarioComparativo.ValidarUsuariosExistentesUsuariosComparativosAsync();
    }
}
