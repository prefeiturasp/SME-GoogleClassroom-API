using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosQueSeraoRemovidosUseCase
    {
        Task<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>> Executar(FiltroObterUsuariosQueSeraoRemovidosDto filtro);
    }
}
