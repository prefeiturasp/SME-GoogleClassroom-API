using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIncluirAlunoCelpGoogleUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}
