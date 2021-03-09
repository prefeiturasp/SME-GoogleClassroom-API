using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<CursoEol>> Executar(FiltroObterCursosIncluirGoogleDto filtro);
    }
}