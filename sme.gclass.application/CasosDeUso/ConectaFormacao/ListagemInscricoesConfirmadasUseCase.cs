using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasUseCase : IListagemInscricoesConfirmadasUseCase
    {
        private readonly IMediator mediator;

        public ListagemInscricoesConfirmadasUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<InscricaoRetornoDTO>> Executar(long codigoDaTurma)
        {
            return await mediator.Send(new ListagemInscricoesConfirmadasQuery(codigoDaTurma));
        }
    }
}