using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUnidadeOrganizacionalUsuarioCommandHandler : IRequestHandler<AtualizarUnidadeOrganizacionalUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorio;

        public AtualizarUnidadeOrganizacionalUsuarioCommandHandler(IRepositorioUsuario repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<bool> Handle(AtualizarUnidadeOrganizacionalUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorio.AtualizarUnidadeOrganizacionalAsync(request.UsuarioId, request.UnidadeOrganizacional);
    }
}
