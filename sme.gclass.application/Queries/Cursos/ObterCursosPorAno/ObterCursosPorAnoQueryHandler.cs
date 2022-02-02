using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoQueryHandler : IRequestHandler<ObterCursosPorAnoQuery, (IEnumerable<CursoDto> cursos, int? totalPaginas)>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursosPorAnoQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new System.ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<(IEnumerable<CursoDto> cursos, int? totalPaginas)> Handle(ObterCursosPorAnoQuery request, CancellationToken cancellationToken)
            => await repositorioCurso.ObterCursosPorAno(request.AnoLetivo, request.CursoId, request.Pagina, request.QuantidadeRegistrosPagina);
    }
}
