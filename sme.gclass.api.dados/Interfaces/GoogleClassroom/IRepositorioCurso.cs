using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCurso
    {
        Task<PaginacaoResultadoDto<Curso>> ObterTodosCursosAsync(Paginacao paginacao);

        Task<long> SalvarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao);
        Task<bool> ExisteCursoPorTurmaComponenteCurricular(long turmaId, long componenteCurricularId);
    }
}
