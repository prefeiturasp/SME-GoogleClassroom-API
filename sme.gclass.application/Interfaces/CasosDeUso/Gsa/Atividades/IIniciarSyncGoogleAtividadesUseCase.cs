using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleAtividadesUseCase
    {
        Task Executar(long? cursoId = null, int? pagina = null, int? totalPaginas = null);
    }
}
