using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPAPPAEEorTipoEscolaAnoQueryHandler : IRequestHandler<ObterProfessoresPAPPAEEorTipoEscolaAnoQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionario;

        public ObterProfessoresPAPPAEEorTipoEscolaAnoQueryHandler(IRepositorioFuncionarioEol repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(ObterProfessoresPAPPAEEorTipoEscolaAnoQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionario.ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(request.CodigoDre, request.TipoEscola, request.TipoConsulta);
    }
}