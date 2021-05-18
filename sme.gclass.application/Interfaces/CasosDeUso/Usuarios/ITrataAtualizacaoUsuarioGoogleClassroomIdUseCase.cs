using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface ITrataAtualizacaoUsuarioGoogleClassroomIdUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}