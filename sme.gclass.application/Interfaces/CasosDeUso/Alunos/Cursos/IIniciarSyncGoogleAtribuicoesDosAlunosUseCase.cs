using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSyncGoogleAtribuicoesDosAlunosUseCase
    {
        Task<bool> Executar();
    }
}