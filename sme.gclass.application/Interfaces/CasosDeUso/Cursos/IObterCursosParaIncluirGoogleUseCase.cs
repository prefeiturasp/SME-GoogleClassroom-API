using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<CursoParaIncluirGoogleDto>> Executar(FiltroObterCursosIncluirGoogleDto filtro);
    }
}