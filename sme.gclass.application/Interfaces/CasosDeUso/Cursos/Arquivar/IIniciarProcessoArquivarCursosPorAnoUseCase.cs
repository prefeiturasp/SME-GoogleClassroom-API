using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarProcessoArquivarCursosPorAnoUseCase
    {
        Task Executar(int ano, long? turmaId = null);
    }
}
