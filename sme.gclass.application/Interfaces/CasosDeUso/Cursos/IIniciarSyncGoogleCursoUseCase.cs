using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleCursoUseCase
    {
        Task<bool> Executar(long? turmaId, long? componenteCurricularId, bool recriarCursoSeExistirNaBaseDeDados);
    }
}