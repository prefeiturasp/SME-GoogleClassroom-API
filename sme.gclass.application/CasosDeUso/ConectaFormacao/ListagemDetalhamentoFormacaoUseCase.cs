using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDetalhamentoFormacaoUseCase : IListagemDetalhamentoFormacaoUseCase
    {
        private readonly IMediator mediator;

        public ListagemDetalhamentoFormacaoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> Executar(int ano)
        {
            return await mediator.Send(new ListagemDetalhamentoFormacaoQuery(ano));
        }
    }
}