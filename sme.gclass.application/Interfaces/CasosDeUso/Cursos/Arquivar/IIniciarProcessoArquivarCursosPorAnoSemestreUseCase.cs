using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarProcessoArquivarCursosPorAnoSemestreUseCase
    {
        Task Executar(int ano, int? semestre);
    }
}
