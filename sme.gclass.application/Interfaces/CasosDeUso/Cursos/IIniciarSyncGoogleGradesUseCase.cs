using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleGradesUseCase
    {
        Task<bool> Executar();
    }
}