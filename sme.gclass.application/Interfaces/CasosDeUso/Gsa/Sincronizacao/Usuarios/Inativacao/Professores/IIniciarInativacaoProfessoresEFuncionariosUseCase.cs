using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarInativacaoProfessoresEFuncionariosUseCase
    {
        Task<bool> Executar(string rf, string cpf);
    }
}
