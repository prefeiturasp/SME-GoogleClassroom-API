using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosPaginadosQueryHandler : IRequestHandler<ObterCursosComparativosPaginadosQuery, PaginacaoResultadoDto<CursoGsaDto>>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public ObterCursosComparativosPaginadosQueryHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo ?? throw new System.ArgumentNullException(nameof(repositorioCursoComparativo));
        }
        public async Task<PaginacaoResultadoDto<CursoGsaDto>> Handle(ObterCursosComparativosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoComparativo.ObterCursosComparativosAsync(request.Paginacao, request.Secao, request.Nome, request.Descricao);
        }
    }
}
