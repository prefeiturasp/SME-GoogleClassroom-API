using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleAtividadesUseCase
    {
        Task Executar(IniciarSyncGoogleAtividadesDto filtro);
        Task Executar(long? cursoId = null, int? pagina = null, int? totalPaginas = null);
    }
}
