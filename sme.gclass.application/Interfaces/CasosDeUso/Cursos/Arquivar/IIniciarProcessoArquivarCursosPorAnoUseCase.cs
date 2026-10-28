using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarProcessoArquivarCursosPorAnoUseCase
    {
        Task<bool> Executar(int? anoLetivo, long? turmaId = null);
    }
}
