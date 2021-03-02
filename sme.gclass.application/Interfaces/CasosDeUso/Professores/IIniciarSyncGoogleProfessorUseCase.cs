using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleProfessorUseCase
    {
        Task<bool> Executar();
    }
}