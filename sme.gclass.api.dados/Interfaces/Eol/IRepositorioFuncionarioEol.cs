using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioFuncionarioEol
    {
        Task<PaginacaoResultadoDto<FuncionarioParaInclusaoDto>> ObterFuncionariosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao);
    }
}