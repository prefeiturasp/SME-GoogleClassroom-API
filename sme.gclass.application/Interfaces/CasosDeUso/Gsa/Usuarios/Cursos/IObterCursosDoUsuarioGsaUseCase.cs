using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosDoUsuarioGsaUseCase
    {
        Task<ConsultaCursosDoUsuarioGsa> Executar(string usuarioId);
    }
}