using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoLetivoSemestreQueryHandler : IRequestHandler<ObterCursosPorAnoLetivoSemestreQuery, IEnumerable<CursoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosPorAnoLetivoSemestreQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<IEnumerable<CursoEolDto>> Handle(ObterCursosPorAnoLetivoSemestreQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterCursosPorAnoLetivoSemestre(request.AnoLetivo);
    }
}
