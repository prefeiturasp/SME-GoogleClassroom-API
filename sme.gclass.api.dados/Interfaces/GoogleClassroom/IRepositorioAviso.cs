using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAviso
    {
        Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId);
        Task<int> SalvarAsync(AvisoGsa avisoGsa);
    }
}
