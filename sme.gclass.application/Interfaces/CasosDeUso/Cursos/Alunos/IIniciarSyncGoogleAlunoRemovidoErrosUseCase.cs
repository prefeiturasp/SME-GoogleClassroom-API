using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleAlunosRemovidosErrosUseCase
    {
        Task<bool> Executar();
    }
}