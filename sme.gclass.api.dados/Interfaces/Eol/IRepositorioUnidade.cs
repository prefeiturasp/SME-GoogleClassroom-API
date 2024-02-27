using SME.GoogleClassroom.Infra.Dtos.Gsa.FormacaoCidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces.Eol
{
    public interface IRepositorioUnidade
    {
        Task<IEnumerable<UnidadeDto>> ObterUnidadesPorCodigos(string[] codigos);
    }
}
