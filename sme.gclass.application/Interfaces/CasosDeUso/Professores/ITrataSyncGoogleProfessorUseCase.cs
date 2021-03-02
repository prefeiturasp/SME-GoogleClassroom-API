using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ITrataSyncGoogleProfessorUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagem);
    }
}