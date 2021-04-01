using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleCursoErrosUseCase
    {
        Task<bool> Executar();
    }
}