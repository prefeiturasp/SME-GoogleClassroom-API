using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoCursosUsuariosRemoverGsaUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagem);
    }
}
