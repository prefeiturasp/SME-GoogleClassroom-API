using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;


namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAviso
    {
        Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId);
        Task<int> SalvarAsync(AvisoGsa avisoGsa);
    }
}