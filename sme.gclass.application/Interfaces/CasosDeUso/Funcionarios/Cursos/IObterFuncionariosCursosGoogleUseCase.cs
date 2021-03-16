using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosCursosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> Executar(FiltroObterFuncionariosCursosCadastradosDto filtro);
    }
}