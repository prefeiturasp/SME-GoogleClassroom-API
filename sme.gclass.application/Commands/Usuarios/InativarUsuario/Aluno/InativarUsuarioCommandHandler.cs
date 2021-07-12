using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarUsuarioCommandHandler : IRequestHandler<InativarUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorio;

        public InativarUsuarioCommandHandler(IRepositorioUsuario repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<bool> Handle(InativarUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorio.InativarAsync(request.UsuarioId);
    }


}
