using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemAreaPromotoraQueryHandler : IRequestHandler<ListagemAreaPromotoraQuery, IEnumerable<AreaPromotoraDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;

        public ListagemAreaPromotoraQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
        }

        public Task<IEnumerable<AreaPromotoraDTO>> Handle(ListagemAreaPromotoraQuery request, CancellationToken cancellationToken)
        {
            return repositorioConectaFormacao.ListagemAreaPromotora();
        }
    }
}
