using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioProfessorEol
    {
        Task<PaginacaoResultadoDto<ProfessorEol>> ObterProfessoresParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<ProfessorCursoEol>> ObterCursosDoProfessorParaInclusaoAsync(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>> ObterAtribuicoesDeCursosDoProfessorAsync(DateTime dataReferencia, Paginacao paginacao, string rf,
            long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<ProfessorEol> ObterProfessorParaTratamentoDeErroAsync(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<AlunoCursoEol>> ObterProfessoresPorDreComponenteCurricularModalidade(string componentesCurricularIds, string modalidadesIds, int[] tipoEscola, int anoLetivo, string anoTurma, string[] agruparPorDres);
        Task<IEnumerable<RemoverAtribuicaoProfessorCursoEolDto>> ObterProfessoresParaRemoverCurso(string turmaId, DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<long>> ObterCodigosProfessoresInativosPorAnoLetivo(int anoLetivo, DateTime dataReferencia, string rf);
        Task<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>> ObterProfessoresParaRemoverCursoPaginado(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao);
    }
}