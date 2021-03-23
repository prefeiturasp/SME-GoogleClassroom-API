using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ITrataSyncGoogleFuncionarioIndiretoUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagem);
    }
}