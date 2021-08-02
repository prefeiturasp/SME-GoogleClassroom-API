using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosRemovidosCursosPorIdQueryHandler : IRequestHandler<ObterFuncionariosRemovidosCursosPorIdQuery, PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsa repositorio;

        public ObterFuncionariosRemovidosCursosPorIdQueryHandler(IRepositorioCursoUsuarioRemovidoGsa repositorio)
        {
            this.repositorio = repositorio ?? throw new System.ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Handle(ObterFuncionariosRemovidosCursosPorIdQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterFuncionariosRemovidosCursosPorId(request.Paginacao, request.CursoId);
    }
}
