using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQueryHandler : IRequestHandler<ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery, bool>
    {
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;

        public ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQueryHandler(IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa)
        {
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
        }

        public async Task<bool> Handle(ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioCursoGsa.ExistePorUsuarioIdCursoIdAsync(request.UsuarioId, request.CursoId);
    }
}