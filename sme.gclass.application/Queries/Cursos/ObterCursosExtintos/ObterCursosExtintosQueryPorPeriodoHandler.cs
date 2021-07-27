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
    public class ObterCursosExtintosQueryPorPeriodoQueryHandler : IRequestHandler<ObterCursosExtintosQueryPorPeriodoQuery, IEnumerable<CursoExtintoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosExtintosQueryPorPeriodoQueryHandler (IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<IEnumerable<CursoExtintoEolDto>> Handle(ObterCursosExtintosQueryPorPeriodoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterCursosExtintosPorPeriodo(request.DataInicio, request.DataFim, request.AnoLetivo, request.TurmaId);

    }
}
