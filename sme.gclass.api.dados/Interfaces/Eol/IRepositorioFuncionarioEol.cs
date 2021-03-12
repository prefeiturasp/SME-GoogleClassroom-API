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
        Task<IEnumerable<FuncionarioCursoEol>> ObterCursosDoFuncionarioParaIncluirAsync(long rf, int anoLetivo);
    }
}