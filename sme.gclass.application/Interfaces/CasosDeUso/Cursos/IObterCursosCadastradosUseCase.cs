using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosCadastradosUseCase
    {
        Task<PaginacaoResultadoDto<CursoGoogleDto>> Executar(FiltroObterCursosCadastradosDto filtro);
    }
}
