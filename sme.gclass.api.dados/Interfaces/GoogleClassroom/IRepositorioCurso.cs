using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCurso
    {
        Task<PaginacaoResultadoDto<Curso>> ObterTodosCursosAsync(Paginacao paginacao);

    }
}
