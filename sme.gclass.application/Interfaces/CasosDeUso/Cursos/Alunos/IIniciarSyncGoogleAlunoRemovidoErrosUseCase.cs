using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleUsuariosRemovidosErrosUseCase
    {
        Task<bool> Executar();
    }
}