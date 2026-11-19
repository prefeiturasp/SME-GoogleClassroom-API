using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAtividadesUseCase
    {
        Task<PaginacaoResultadoDto<AtividadeDto>> Executar(FiltroAtividadesDto filtro);
    }
}