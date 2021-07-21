using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosUsuariosRemovidosPorCursoIdQueryHandler : IRequestHandler<ObterAlunosCursosUsuariosRemovidosPorCursoIdQuery, PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsa repositorioCursoUsuarioRemovidoGsa;

        public ObterAlunosCursosUsuariosRemovidosPorCursoIdQueryHandler(IRepositorioCursoUsuarioRemovidoGsa repositorio)
        {
            this.repositorioCursoUsuarioRemovidoGsa = repositorio ?? throw new System.ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Handle(ObterAlunosCursosUsuariosRemovidosPorCursoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoUsuarioRemovidoGsa.ObterAlunosCursosRemovidosPorCursoId(request.Paginacao, request.CursoId);
        }
    }
}
