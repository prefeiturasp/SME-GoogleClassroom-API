using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosCursosUsuariosRemovidosUseCase
    {
        Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Executar(FiltroObterAlunosCursosUsuariosRemovidosDto filtro);
    }
}
