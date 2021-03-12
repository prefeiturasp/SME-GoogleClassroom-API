using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleGradesDosAlunosUseCase
    {
        Task<bool> Executar();
    }
}