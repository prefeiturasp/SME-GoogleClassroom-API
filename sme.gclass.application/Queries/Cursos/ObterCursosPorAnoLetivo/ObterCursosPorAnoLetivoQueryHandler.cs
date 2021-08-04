using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoLetivoQueryHandler : IRequestHandler<ObterCursosPorAnoLetivoQuery, IEnumerable<CursoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosPorAnoLetivoQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<IEnumerable<CursoEolDto>> Handle(ObterCursosPorAnoLetivoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterCursosPorAnoLetivo(request.AnoLetivo, request.TurmaId);
    }
}
