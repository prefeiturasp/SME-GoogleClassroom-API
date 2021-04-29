using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class FinalizarAtualizacaoUsuarioGoogleClassroomIdCommandHandler : AsyncRequestHandler<FinalizarAtualizacaoUsuarioGoogleClassroomIdCommand>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public FinalizarAtualizacaoUsuarioGoogleClassroomIdCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        protected override async Task Handle(FinalizarAtualizacaoUsuarioGoogleClassroomIdCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.FinalizarAtualizacaoUsuarioGoogleClassroomIdAsync();
    }
}