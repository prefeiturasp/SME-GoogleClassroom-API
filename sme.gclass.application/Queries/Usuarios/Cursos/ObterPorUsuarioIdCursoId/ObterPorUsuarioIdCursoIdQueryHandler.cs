using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPorUsuarioIdCursoIdQueryHandler : IRequestHandler<ObterPorUsuarioIdCursoIdQuery, CursoUsuario>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterPorUsuarioIdCursoIdQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario;
        }

        public async Task<CursoUsuario> Handle(ObterPorUsuarioIdCursoIdQuery request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.ObterPorUsuarioIdCursoIdAsync(request.UsuarioId, request.CursoId);
    }
}