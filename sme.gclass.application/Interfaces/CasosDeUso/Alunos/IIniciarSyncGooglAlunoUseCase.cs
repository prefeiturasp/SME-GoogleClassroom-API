using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGooglAlunoUseCase
    {
        Task<bool> Executar();
    }
}