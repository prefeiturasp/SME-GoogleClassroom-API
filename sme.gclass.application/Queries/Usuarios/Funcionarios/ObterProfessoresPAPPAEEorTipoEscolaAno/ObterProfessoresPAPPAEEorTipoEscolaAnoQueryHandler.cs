using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPAPPAEEorTipoEscolaAnoQueryHandler : IRequestHandler<ObterProfessoresPAPPAEEorTipoEscolaAnoQuery, IEnumerable<string>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionario;

        public ObterProfessoresPAPPAEEorTipoEscolaAnoQueryHandler(IRepositorioFuncionarioEol repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public async Task<IEnumerable<string>> Handle(ObterProfessoresPAPPAEEorTipoEscolaAnoQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionario.ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(request.CodigoDre, request.TipoEscola, request.TipoConsulta);
    }
}