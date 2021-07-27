using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoRemoverProfessorCursoGsaUseCase
    {
        Task<bool> Executar(long? turmaId = null, bool processarAlunos = true, bool processarProfessores = true);
    }
}
