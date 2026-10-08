using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class FinalizarAtualizacaoUsuarioGoogleClassroomIdCommandHandler : IRequestHandler<FinalizarAtualizacaoUsuarioGoogleClassroomIdCommand>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public FinalizarAtualizacaoUsuarioGoogleClassroomIdCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task Handle(FinalizarAtualizacaoUsuarioGoogleClassroomIdCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.FinalizarAtualizacaoUsuarioGoogleClassroomIdAsync();
    }
}