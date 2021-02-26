using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Funcionarios
{
    public interface ITrataSyncGoogleFuncionarioUseCase
    {
        Task Executar(MensagemRabbit mensagem);
    }
}