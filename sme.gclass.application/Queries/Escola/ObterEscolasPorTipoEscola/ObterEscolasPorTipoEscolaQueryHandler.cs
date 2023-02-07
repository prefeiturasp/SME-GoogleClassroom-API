using MediatR;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class
        ObterEscolasPorTipoEscolaQueryHandler : IRequestHandler<ObterEscolasPorTipoEscolaQuery, IEnumerable<EscolaDTO>>
    {
        private readonly IRepositorioEscolaEol repositorioEscola;

        public ObterEscolasPorTipoEscolaQueryHandler(IRepositorioEscolaEol repositorioEscola)
        {
            this.repositorioEscola = repositorioEscola ?? throw new ArgumentNullException(nameof(repositorioEscola));
        }

        public async Task<IEnumerable<EscolaDTO>> Handle(ObterEscolasPorTipoEscolaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioEscola.ObterEscolas(request.TiposEscola, request.CodigoDRE, request.SiglaTipoEscola);
        }
    }
}