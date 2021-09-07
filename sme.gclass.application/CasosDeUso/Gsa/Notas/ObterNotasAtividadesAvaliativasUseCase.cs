using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasAtividadesAvaliativasUseCase : AbstractUseCase, IObterNotasAtividadesAvaliativasUseCase
    {
        public ObterNotasAtividadesAvaliativasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<NotasAtividadesDto>> Executar(FiltroNotasAtividadesDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterNotasAtividadesAvaliativasQuery(paginacao, filtro.AtividadeId, filtro.DataReferencia));
        }
    }
}
