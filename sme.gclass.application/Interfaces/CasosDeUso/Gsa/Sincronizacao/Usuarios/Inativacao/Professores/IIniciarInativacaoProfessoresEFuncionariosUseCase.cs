using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarInativacaoProfessoresEFuncionariosUseCase
    {
        Task<bool> Executar(string codigo, string cpf, bool processarProfessoresEFuncionarios, bool processarFuncionariosIndiretos);
    }
}
