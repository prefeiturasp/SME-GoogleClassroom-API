using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterComparativoDeCursosUseCase
    {
        Task<PaginacaoResultadoDto<CursoComparativoDto>> Executar(FiltroObterComparativoCursoDto filtro);
    }
}
