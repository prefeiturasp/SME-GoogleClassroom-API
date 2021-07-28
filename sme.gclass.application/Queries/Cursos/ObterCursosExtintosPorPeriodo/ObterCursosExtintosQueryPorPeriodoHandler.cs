using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosPorPeriodoQueryHandler : IRequestHandler<ObterCursosExtintosPorPeriodoQuery, IEnumerable<CursoExtintoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosExtintosPorPeriodoQueryHandler (IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<IEnumerable<CursoExtintoEolDto>> Handle(ObterCursosExtintosPorPeriodoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterCursosExtintosPorPeriodo(request.DataInicio, request.DataFim, request.AnoLetivo, request.TurmaId);

    }
}
