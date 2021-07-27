using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ITrataSyncGoogleAlunoInativoErroUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}