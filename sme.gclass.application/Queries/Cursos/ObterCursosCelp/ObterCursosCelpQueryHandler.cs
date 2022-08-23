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
    public class ObterCursosCelpQueryHandler : IRequestHandler<ObterCursosCelpQuery, IReadOnlyList<CursoCelpEolDto>>
    {
        private readonly IRepositorioCursoCelpEol repositorioCursoCelpEol;

        public ObterCursosCelpQueryHandler(IRepositorioCursoCelpEol repositorioCursoCelpEol)
        {
            this.repositorioCursoCelpEol = repositorioCursoCelpEol ?? throw new ArgumentNullException(nameof(repositorioCursoCelpEol));
        }

        public async Task<IReadOnlyList<CursoCelpEolDto>> Handle(ObterCursosCelpQuery request, CancellationToken cancellationToken)
        {
            return (await repositorioCursoCelpEol.ObterCursosCelpPorComponentesEAno(request.Componentes,
                request.AnoLetivo)).ToList();
        }
    }
}