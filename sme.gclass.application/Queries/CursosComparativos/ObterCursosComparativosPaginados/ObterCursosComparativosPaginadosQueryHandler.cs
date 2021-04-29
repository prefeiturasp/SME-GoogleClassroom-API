using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosPaginadosQueryHandler : IRequestHandler<ObterCursosComparativosPaginadosQuery, PaginacaoResultadoDto<CursoComparativoDto>>
    {
        private readonly IRepositorioCursoComparativo repositorioCursoComparativo;

        public ObterCursosComparativosPaginadosQueryHandler(IRepositorioCursoComparativo repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo ?? throw new System.ArgumentNullException(nameof(repositorioCursoComparativo));
        }
        public async Task<PaginacaoResultadoDto<CursoComparativoDto>> Handle(ObterCursosComparativosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoComparativo.ObterCursosComparativosAsync(request.Paginacao, request.Secao);
        }
    }
}
