using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IRealizarCargaTurmasInativacaoUsuarioUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}
