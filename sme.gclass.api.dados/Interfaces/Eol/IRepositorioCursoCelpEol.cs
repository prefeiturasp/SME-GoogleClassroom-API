using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoCelpEol
    {
        Task<IEnumerable<CursoCelpEolDto>> ObterCursosCelpPorComponentesEAnoLetivo(IEnumerable<int> componentes, int anoLetivo, DateTime dataUltimaExecucao);
    }
}