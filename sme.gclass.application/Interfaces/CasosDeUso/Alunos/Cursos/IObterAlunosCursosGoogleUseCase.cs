using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosCursosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<AlunoCursosCadastradosDto>> Executar(FiltroObterAlunosCursosCadastradosDto filtro);
    }
}