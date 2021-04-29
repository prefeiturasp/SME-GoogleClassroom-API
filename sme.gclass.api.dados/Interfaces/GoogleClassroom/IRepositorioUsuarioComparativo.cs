using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioComparativo
    {
        Task<bool> SalvarAsync(UsuarioComparativo usuarioComparativo);
    }
}
