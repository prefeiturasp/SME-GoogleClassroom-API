using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoEol
    {
        Task<PaginacaoResultadoDto<CursoEol>> ObterCursosParaInclusao(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime? dataUltimaExecucao, int anoLetivo, Paginacao paginacao, long? componenteCurricularId, long? turmaId);
        Task<CursoEol> ObterCursoPorIdParaInclusao(long componenteCurricularId, long turmaId, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<ProfessorCursoEol>> ObterProfessoresDoCursoParaIncluirGoogleAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<AlunoCursoEol>> ObterAlunosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<PaginacaoResultadoDto<GradeCursoEol>> ObterGradesDeCursosAsync(DateTime ultimaDataExecucao, Paginacao paginacao, long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<FuncionarioCursoEol>> ObterFuncionariosDoCursoParaIncluirAsync(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<bool> ExisteTurmaAtivaPorId(long turmaId);
        Task<IEnumerable<CursoExtintoEolDto>> ObterCursosExtintosPorPeriodo(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId);
        Task<PaginacaoResultadoDto<CursoExtintoEolDto>> ObterCursosExtintosPorPeriodoPaginado(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId, Paginacao paginacao);
        Task<PaginacaoResultadoDto<CursoArquivarEolDto>> ObterCursosParaArquivarPorAnoPaginado(int anoLetivo, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<CursoEolDto>> ObterTurmasConcluidasPorAnoLetivo(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, long? turmaId);
        Task<IEnumerable<FuncionarioCursoEol>> ObterFuncionariosDoCursoCelpParaIncluirAsync(int requestAnoLetivo, long requestTurmaId, long requestComponenteCurricularId);
    }
}