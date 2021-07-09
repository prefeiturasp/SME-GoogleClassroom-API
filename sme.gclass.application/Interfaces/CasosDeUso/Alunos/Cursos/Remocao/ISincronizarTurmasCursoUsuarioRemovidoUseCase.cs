using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizarTurmasCursoUsuarioRemovidoUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}
