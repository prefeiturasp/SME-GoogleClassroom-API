using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ICarregarArquivamentoCursosExtintosUseCase
    {
        Task<bool> Executar(long? turmaId);
    }
}
