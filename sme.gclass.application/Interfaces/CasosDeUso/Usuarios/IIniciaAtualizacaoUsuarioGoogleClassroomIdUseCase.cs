using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciaAtualizacaoUsuarioGoogleClassroomIdUseCase
    {
        Task<bool> Executar(int registrosPorPagina);
    }
}