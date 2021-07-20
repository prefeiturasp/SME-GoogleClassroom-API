using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Usuarios.Erros
{
    public interface ITrataSyncGoogleUsuarioErroUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}