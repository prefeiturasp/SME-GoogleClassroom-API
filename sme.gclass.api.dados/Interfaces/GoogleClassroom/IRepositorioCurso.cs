using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCurso
    {
        Task<IEnumerable<CursoParaInclusaoDto>> ObterCursosParaInclusao(DateTime dataUltimaExecucao);
    }
}