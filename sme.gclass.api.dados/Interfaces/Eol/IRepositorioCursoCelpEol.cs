using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoCelpEol
    {
        Task<IEnumerable<CursoCelpEolDto>> ObterCursosCelpPorComponentesEAno(IReadOnlyList<int> componentes, int anoLetivo);
    }
}