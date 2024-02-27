using MediatR;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDeAreaPromotoraUseCase : IListagemDeAreaPromotoraUseCase
    {
        private readonly IMediator mediator;

        public ListagemDeAreaPromotoraUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<IEnumerable<AreaPromotoraDTO>> Executar()
        {
            return mediator.Send(ListagemAreaPromotoraQuery.Instancia());
        }
    }
}
