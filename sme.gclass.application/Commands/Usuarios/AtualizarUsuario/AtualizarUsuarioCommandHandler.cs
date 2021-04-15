using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public AtualizarUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.AtualizarAsync(request.Id, request.Nome, request.OrganizationPath) > 0;
    }
}