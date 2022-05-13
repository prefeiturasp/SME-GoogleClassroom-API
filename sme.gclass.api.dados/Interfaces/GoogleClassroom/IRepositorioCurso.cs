using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
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
        Task<IEnumerable<long>> ObterIdsCursosPorTurma(long turmaId);
        Task<(IEnumerable<CursoDto> cursos, int? totalPaginas)> ObterCursosPorAno(int anoLetivo, long? cursoId = null, int? pagina = null, int? quantidadeRegistrosPagina = null);
        Task<CursoGoogle> ObterCursoPorId(long id);
        Task<bool> AlterarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao);
        Task<long> ExisteCursoPorNome(string nome);
        Task<CursoGoogle> ObterCursoPorEmailNome(string email, string nome);
        Task<IEnumerable<CursoGoogleDtoParaIntegracao>> ObterCursosPorIdsParaIntegracaoAsync(IEnumerable<long> ids);
    }
}
