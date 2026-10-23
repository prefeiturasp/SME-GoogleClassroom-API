using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterGradesDeCursosUseCase
    {
        Task<PaginacaoResultadoDto<GradeCursoEolDto>> Executar(FiltroObterGradesDeCursosDto filtro);
    }
}