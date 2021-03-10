using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterProfessoresCursosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> Executar(FiltroObterProfessoresCursosCadastradosDto filtro);
    }
}