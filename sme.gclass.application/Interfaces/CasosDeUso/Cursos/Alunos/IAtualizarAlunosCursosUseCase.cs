using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IAtualizarAlunosCursosUseCase
    {
        Task<bool> Executar(long? turmaId, long? componenteCurricularId);
    }
}
