using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoDoUsuarioPorUsuarioIdCursoIdQueryHandler : IRequestHandler<ExisteCursoDoUsuarioPorUsuarioIdCursoIdQuery, bool>
    {
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;

        public ExisteCursoDoUsuarioPorUsuarioIdCursoIdQueryHandler(IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa)
        {
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
        }

        public async Task<bool> Handle(ExisteCursoDoUsuarioPorUsuarioIdCursoIdQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioCursoGsa.ExistePorUsuarioIdCursoIdAsync(request.UsuarioId, request.CursoId);
    }
}