using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoCursosUsuariosRemoverGsaUseCase
    {
        Task<bool> Executar(long? turmaId = null, bool processarAlunos = true, bool processarProfessores = true,
            bool processarFuncionario = true);
    }
}