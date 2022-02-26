using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioDreEol
    {
        Task<IEnumerable<DreDto>> ObterDres(string codigoDre);
    }
}
