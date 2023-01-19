using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioFuncionarioEol
    {
        Task<PaginacaoResultadoDto<FuncionarioEol>> ObterFuncionariosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<FuncionarioEol> ObterFuncionarioParaTratamentoDeErroAsync(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<FuncionarioCursoEol>> ObterCursosDoFuncionarioParaIncluirAsync(long? rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>> ObterFuncionariosParaRemoverCursoPaginado(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto);
        Task<IEnumerable<AlunoCursoEol>> ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(string codigoDre, int[] tipoEscola, int anoLetivo);
        Task<IEnumerable<AlunoCursoEol>> ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(string codigoDre, int[] tipoEscola, int tipoConsulta);
        Task<IEnumerable<RemoverAtribuicaoFuncionarioTurmaEolDto>> ObterFuncionariosParaRemoverCurso(string turmaId, DateTime dataInicio, DateTime dataFim, ParametrosCargaInicialDto parametrosCargaInicialDto);        
        Task<PaginacaoResultadoDto<FuncionarioEol>> ObterFuncionariosQueSeraoInativados(Paginacao paginacao, DateTime dataReferencia, string codigoRf);
        Task<IEnumerable<FuncionarioEolGsaDto>> ObterFuncionarioEolPorUeAnoLetivo(string anoLetivo, string codigoEscola,bool escolaCieja = false);
    }
}