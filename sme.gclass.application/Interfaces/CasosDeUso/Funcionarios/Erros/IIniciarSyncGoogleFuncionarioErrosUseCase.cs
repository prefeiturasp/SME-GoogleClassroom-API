using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleFuncionarioErrosUseCase
    {
        Task<bool> Executar();
    }
}