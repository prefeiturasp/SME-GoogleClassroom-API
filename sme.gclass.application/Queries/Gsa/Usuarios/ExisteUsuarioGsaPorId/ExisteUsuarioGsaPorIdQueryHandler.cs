using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteUsuarioGsaPorIdQueryHandler : IRequestHandler<ExisteUsuarioGsaPorIdQuery, bool>
    {
        private readonly IRepositorioUsuarioGsa repositorioUsuarioGsa;

        public ExisteUsuarioGsaPorIdQueryHandler(IRepositorioUsuarioGsa repositorioUsuarioGsa)
        {
            this.repositorioUsuarioGsa = repositorioUsuarioGsa;
        }

        public async Task<bool> Handle(ExisteUsuarioGsaPorIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioGsa.ExistePorIdAsync(request.CursoId);
    }
}