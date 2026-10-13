using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Atividades;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAtividadesUseCase
    {
        Task<PaginacaoResultadoDto<AtividadeDto>> Executar(FiltroAtividadesDto filtro);
    }
}