using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces.Eol;

namespace SME.GoogleClassroom.Aplicacao.Queries.UE.ObterTipoDaUe
{
    public class ObterTipoDaEscolaQueryHandler : IRequestHandler<ObterTipoDaEscolaQuery,int>
    {
        private readonly IRepositorioEscolaEol repositorioEscolaEol;

        public ObterTipoDaEscolaQueryHandler(IRepositorioEscolaEol escolaEol)
        {
            repositorioEscolaEol = escolaEol ?? throw new ArgumentNullException(nameof(escolaEol));
        }

        public async Task<int> Handle(ObterTipoDaEscolaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioEscolaEol.ObterTipoDaEscolaPorCodigoEscola(request.CodigoEscola);
        }
    }
}