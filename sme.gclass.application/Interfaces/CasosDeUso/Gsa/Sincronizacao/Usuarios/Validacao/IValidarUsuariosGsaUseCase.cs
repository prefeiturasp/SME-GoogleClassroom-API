using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IValidarUsuariosGsaUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}
