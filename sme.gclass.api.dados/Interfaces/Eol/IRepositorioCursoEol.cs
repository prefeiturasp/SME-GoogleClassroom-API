using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoEol
    {
        Task<PaginacaoResultadoDto<CursoParaInclusaoDto>> ObterCursosParaInclusao(DateTime dataUltimaExecucao, Paginacao paginacao, long? componenteCurricularId, long? turmaId);
    }
}