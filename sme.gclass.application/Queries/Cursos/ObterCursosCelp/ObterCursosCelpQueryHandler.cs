using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpQueryHandler : IRequestHandler<ObterCursosCelpQuery, IEnumerable<CursoCelpEolDto>>
    {
        private readonly IRepositorioCursoCelpEol repositorioCursoCelpEol;

        public ObterCursosCelpQueryHandler(IRepositorioCursoCelpEol repositorioCursoCelpEol)
        {
            this.repositorioCursoCelpEol = repositorioCursoCelpEol ?? throw new ArgumentNullException(nameof(repositorioCursoCelpEol));
        }

        public async Task<IEnumerable<CursoCelpEolDto>> Handle(ObterCursosCelpQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoCelpEol.ObterCursosCelpPorComponentesEAnoLetivo(request.Componentes, request.AnoLetivo, request.DataUltimaExecucao);
        }
    }
}