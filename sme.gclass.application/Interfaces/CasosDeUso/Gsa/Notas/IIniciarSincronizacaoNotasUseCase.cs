using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSincronizacaoNotasUseCase
    {
        Task Executar(FiltroNotasAtividadesSincronizacaoDto filtro);
    }
}
