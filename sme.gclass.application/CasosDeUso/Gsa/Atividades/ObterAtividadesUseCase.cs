using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesUseCase : IObterAtividadesUseCase
    {
        private readonly IMediator mediator;

        public ObterAtividadesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AtividadeGsa>> Executar(FiltroAtividadesDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new AtividadesQuery(paginacao,  filtro.DataReferencia, filtro.CursoId));
        }
    }
}