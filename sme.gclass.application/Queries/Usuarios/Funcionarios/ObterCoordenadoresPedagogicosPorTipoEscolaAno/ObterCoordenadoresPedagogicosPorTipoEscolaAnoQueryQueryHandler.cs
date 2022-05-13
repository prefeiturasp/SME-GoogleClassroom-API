using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryHandler : IRequestHandler<ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionario;

        public ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryHandler(IRepositorioFuncionarioEol repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionario.ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(request.CodigoDre, request.TipoEscola, request.AnoLetivo);
    }
}