using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCurso
    {
        Task<PaginacaoResultadoDto<CursoGoogle>> ObterTodosCursosAsync(Paginacao paginacao, long? turmaCodigo, long? componenteCurricularId, long? cursoId, string emailCriador);
        Task<long> SalvarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao);
        Task<bool> ExisteCursoPorTurmaComponenteCurricular(long turmaId, long componenteCurricularId);
        Task<int> ExcluirCursoAsync(long cursoId);
        Task<CursoGoogle> ObterCursoPorTurmaComponenteCurricular(long turmaId, long componenteCurricularId);
        Task<CursoGoogle> ObterCursoPorId(long id);
        Task<bool> AlterarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao);
    }
}
