using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryHandler : IRequestHandler<ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery, IEnumerable<string>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionario;

        public ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryHandler(IRepositorioFuncionarioEol repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public async Task<IEnumerable<string>> Handle(ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionario.ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(request.CodigoDre, request.TipoEscola, request.AnoLetivo);
    }
}