using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioAlunoEol
    {
        Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosParaInclusaoAsync(Paginacao paginacao, int anoLetivo, DateTime? dataReferencia, long? codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<AlunoEol> ObterAlunoParaTratamentoDeErroAsync(long codigoEol, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<AlunoCursoEol>> ObterCursosDoAlunoParaIncluirAsync(long codigoAluno, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<long>> ObterAlunosCodigosInativosPorAnoLetivoETurma(int anoLetivo, long turmaId, DateTime dataInicio, DateTime dataFim, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosQueSeraoRemovidosPorAnoLetivoETurma(ParametrosCargaInicialDto parametrosCargaInicialDto, Paginacao paginacao, int anoLetivo, long turmaId, DateTime dataReferencia, bool ehDataReferenciaPrincipal);
        Task<IEnumerable<long>> ObterCodigosAlunosInativosPorAnoLetivo(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, DateTime dataReferencia, long? alunoId);
        Task<PaginacaoResultadoDto<AlunoEol>> ObterAlunosQueSeraoInativosPorAnoLetivo(Paginacao paginacao, int anoLetivo, DateTime dataReferencia);
        Task<IEnumerable<AlunoCelpDto>> ObterAlunosMatriculadosCelpPorComponenteEAnoLetivo(int componente, int anoLetivo);
    }
}
