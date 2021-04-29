using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.AlunosComparativos
{
    public interface IObterComparativoDeAlunosUseCase
    {
        Task<PaginacaoResultadoDto<CursoComparativoDto>> Executar(FiltroObterComparativoUsuarioDto filtro);
    }
}
