using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaPorAnoQueryHandler : IRequestHandler<ObterCursoGsaPorAnoQuery, IEnumerable<CursoGsaId>>
    {
        IRepositorioCursoGsa repositorioCursoGsa;
        public ObterCursoGsaPorAnoQueryHandler(IRepositorioCursoGsa repositorioCursoGsa)
        {
            this.repositorioCursoGsa = repositorioCursoGsa ?? throw new ArgumentNullException(nameof(repositorioCursoGsa));
        }
        public Task<IEnumerable<CursoGsaId>> Handle(ObterCursoGsaPorAnoQuery request, CancellationToken cancellationToken)
             => repositorioCursoGsa.ObterCursosGsaPorAno(request.AnoLetivo, request.CursoId, request.Pagina, request.QuantidadeRegistrosPagina);
    }
}
