using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleProfessorErrosUseCase
    {
        Task<bool> Executar();
    }
}