using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasConcluidasPorAnoLetivoQueryHandler : IRequestHandler<ObterTurmasConcluidasPorAnoLetivoQuery, IEnumerable<CursoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterTurmasConcluidasPorAnoLetivoQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<IEnumerable<CursoEolDto>> Handle(ObterTurmasConcluidasPorAnoLetivoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterTurmasConcluidasPorAnoLetivo(request.ParametrosCargaInicialDto, request.AnoLetivo, request.TurmaId);
    }
}
