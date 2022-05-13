using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioTurmaEscolaEol
    {
        Task<IEnumerable<long>> ObterTurmasPorCodigoETipo4e8(List<long> codigos);
    }
}