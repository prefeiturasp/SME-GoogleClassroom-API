using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaManualmentePorAnoQueryHandler : IRequestHandler<ObterCursoGsaManualmentePorAnoQuery, IEnumerable<CursoGsaManualmenteDto>>
    {
        IRepositorioCursoGsa repositorioCursoGsa;
        public ObterCursoGsaManualmentePorAnoQueryHandler(IRepositorioCursoGsa repositorioCursoGsa)
        {
            this.repositorioCursoGsa = repositorioCursoGsa ?? throw new ArgumentNullException(nameof(repositorioCursoGsa));
        }
        public Task<IEnumerable<CursoGsaManualmenteDto>> Handle(ObterCursoGsaManualmentePorAnoQuery request, CancellationToken cancellationToken)
            => repositorioCursoGsa.ObterCursosGsaPorAno(request.AnoLetivo, request.CursoId, request.Pagina, request.QuantidadeRegistrosPagina);
    }
}
