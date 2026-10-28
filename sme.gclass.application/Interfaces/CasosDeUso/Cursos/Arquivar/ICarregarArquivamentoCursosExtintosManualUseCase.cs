using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ICarregarArquivamentoCursosExtintosManualUseCase
    {
        Task<bool> Executar(long? turmaId, DateTime? dataReferencia);
    }
}
