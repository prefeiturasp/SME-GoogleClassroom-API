using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresRemovidosCursosPorIdQueryHandler : IRequestHandler<ObterProfessoresRemovidosCursosPorIdQuery, PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsa repositorio;

        public ObterProfessoresRemovidosCursosPorIdQueryHandler(IRepositorioCursoUsuarioRemovidoGsa repositorio)
        {
            this.repositorio = repositorio ?? throw new System.ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Handle(ObterProfessoresRemovidosCursosPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterProfessoresRemovidosCursosPorId(request.Paginacao, request.CursoId);
        }
    }
}
