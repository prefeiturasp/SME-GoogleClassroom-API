using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioAlunoEol
    {
        Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosParaInclusao(DateTime dataReferencia, Paginacao paginacao, long codigoEol);
        Task<IEnumerable<AlunoCursoEol>> ObterCursosDoAlunoParaIncluirAsync(long codigoAluno, int anoLetivo);
    }
}
