using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosRemovidosPorCursoIdQueryHandler : IRequestHandler<ObterAlunosCursosRemovidosPorCursoIdQuery, PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>>
    {
        private readonly IRepositorioUsuarioCursoRemovidoGsa repositorioUsuarioCursoRemovidoGsa;

        public ObterAlunosCursosRemovidosPorCursoIdQueryHandler(IRepositorioUsuarioCursoRemovidoGsa repositorioUsuarioCursoRemovidoGsa)
        {
            this.repositorioUsuarioCursoRemovidoGsa = repositorioUsuarioCursoRemovidoGsa ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioCursoRemovidoGsa));
        }

        public async Task<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>> Handle(ObterAlunosCursosRemovidosPorCursoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuarioCursoRemovidoGsa.ObterAlunosCursosRemovidosPorCursoId(request.Paginacao, request.CursoId);
        }
    }
}
