using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ICarregarArquivamentoCursosExtintosManualUseCase
    {
        Task Executar(long? turmaId);
    }
}
