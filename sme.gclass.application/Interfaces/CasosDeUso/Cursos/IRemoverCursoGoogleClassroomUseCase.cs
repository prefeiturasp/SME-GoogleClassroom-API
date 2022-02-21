using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IRemoverCursoGoogleClassroomUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}