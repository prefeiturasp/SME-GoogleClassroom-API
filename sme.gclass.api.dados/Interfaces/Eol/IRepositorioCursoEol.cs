using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoEol
    {
        Task<PaginacaoResultadoDto<CursoEol>> ObterCursosParaInclusao(DateTime dataUltimaExecucao, Paginacao paginacao, long? componenteCurricularId, long? turmaId);
        Task<IEnumerable<ProfessorCursoEol>> ObterProfessoresDoCursoParaIncluirGoogleAsync(int anoLetivo, long turmaId, long componenteCurricularId);
        Task<IEnumerable<AlunoCursoEol>> ObterAlunosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId);
        Task<PaginacaoResultadoDto<GradeCursoEol>> ObterGradesDeCursosAsync(DateTime ultimaDataExecucao, Paginacao paginacao, long? turmaId, long? componenteCurricularId);
        Task<IEnumerable<FuncionarioCursoEol>> ObterFuncionariosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId);
    }
}