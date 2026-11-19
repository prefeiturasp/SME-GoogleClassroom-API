using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ITratarFilaErrosUseCase
    {
        Task<bool> Executar();
    }
}
