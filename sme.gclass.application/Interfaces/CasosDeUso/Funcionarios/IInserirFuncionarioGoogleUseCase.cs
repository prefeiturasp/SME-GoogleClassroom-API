using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IInserirFuncionarioGoogleUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}