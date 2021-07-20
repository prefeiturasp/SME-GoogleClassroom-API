using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ITrataSyncGoogleRemovidoAlunoCursoErroUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}