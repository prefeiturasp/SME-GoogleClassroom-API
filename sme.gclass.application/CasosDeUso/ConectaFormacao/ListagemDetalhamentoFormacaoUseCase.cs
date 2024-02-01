using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDetalhamentoFormacaoUseCase : IListagemDetalhamentoFormacaoUseCase
    {
        private readonly IMediator mediator;

        public ListagemDetalhamentoFormacaoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<FormacaoDetalhaDTO>> Executar(int ano)
        {
            return await mediator.Send(new ListagemDetalhamentoFormacaoQuery(ano));
        }
    }
}