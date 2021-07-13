using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ITratarAlunosCursoUsuarioRemovidoUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}
