using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InciarAtualizacaoUsuarioGoogleClassroomIdCommandHandler : IRequestHandler<InciarAtualizacaoUsuarioGoogleClassroomIdCommand>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public InciarAtualizacaoUsuarioGoogleClassroomIdCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task Handle(InciarAtualizacaoUsuarioGoogleClassroomIdCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.InciarAtualizacaoUsuarioGoogleClassroomIdAsync();
    }
}