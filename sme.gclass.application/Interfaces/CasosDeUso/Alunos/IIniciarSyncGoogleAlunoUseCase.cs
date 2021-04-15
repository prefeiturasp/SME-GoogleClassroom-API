using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleAlunoUseCase
    {
        Task<bool> Executar(long? codigoAluno);
    }
}