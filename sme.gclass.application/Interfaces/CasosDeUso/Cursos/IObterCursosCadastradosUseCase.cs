using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosCadastradosUseCase
    {
        Task<PaginacaoResultadoDto<CursoGoogle>> Executar(FiltroObterCursosCadastradosDto filtro);
    }
}
