using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioFuncionarioEol
    {
        Task<PaginacaoResultadoDto<FuncionarioEol>> ObterFuncionariosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string rf);
        Task<FuncionarioEol> ObterFuncionarioParaTratamentoDeErroAsync(long rf, int anoLetivo);
        Task<IEnumerable<FuncionarioCursoEol>> ObterCursosDoFuncionarioParaIncluirAsync(long? rf, int anoLetivo);
        Task<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>> ObterFuncionariosParaRemoverCursoPaginado(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao);
        Task<IEnumerable<RemoverAtribuicaoFuncionarioTurmaEolDto>> ObterFuncionariosParaRemoverCurso(string turmaId, DateTime dataInicio, DateTime dataFim);
        Task<PaginacaoResultadoDto<FuncionarioEol>> ObterFuncionariosQueSeraoInativados(Paginacao paginacao, DateTime dataReferencia, string codigoRf);
    }
}