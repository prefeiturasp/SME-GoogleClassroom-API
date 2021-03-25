using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGooglAlunoErrosUseCase
    {
        Task<bool> Executar();
    }
}