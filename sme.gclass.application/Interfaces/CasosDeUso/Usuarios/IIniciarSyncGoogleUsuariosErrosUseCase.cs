using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleUsuariosErrosUseCase
    {
        Task<bool> Executar();
    }
}