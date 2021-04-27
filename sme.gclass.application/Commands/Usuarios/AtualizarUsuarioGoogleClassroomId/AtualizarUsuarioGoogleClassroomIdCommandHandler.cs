using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.AtualizarUsuarioGoogleClassroomId
{
    public class AtualizarUsuarioGoogleClassroomIdCommandHandler : IRequestHandler<AtualizarUsuarioGoogleClassroomIdCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public AtualizarUsuarioGoogleClassroomIdCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> Handle(AtualizarUsuarioGoogleClassroomIdCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.AtualizarUsuarioGoogleClassroomIdAsync(request.UsuarioId, request.GoogleClassroomId) > 0;
    }
}