using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterGradesDeCursosDosAlunosUseCase
    {
        Task<PaginacaoResultadoDto<GradeAlunoCursoEolDto>> Executar(FiltroObterGradesDeCursosDosAlunosDto filtro);
    }
}