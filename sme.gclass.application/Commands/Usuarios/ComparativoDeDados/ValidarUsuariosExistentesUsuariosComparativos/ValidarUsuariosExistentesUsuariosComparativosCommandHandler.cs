using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarUsuariosExistentesUsuariosComparativosCommandHandler : AsyncRequestHandler<ValidarUsuariosExistentesUsuariosComparativosCommand>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioComparativo;

        public ValidarUsuariosExistentesUsuariosComparativosCommandHandler(IRepositorioUsuarioGsa repositorioUsuarioComparativo)
        {
            this.repositorioUsuarioComparativo = repositorioUsuarioComparativo ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioComparativo));
        }

        protected override async Task Handle(ValidarUsuariosExistentesUsuariosComparativosCommand request, CancellationToken cancellationToken) 
            => await repositorioUsuarioComparativo.ValidarUsuariosExistentesUsuariosComparativosAsync();
    }
}
