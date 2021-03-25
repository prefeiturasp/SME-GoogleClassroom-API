using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioErro
    {
        Task<long> SalvarAsync(UsuarioErro usuarioErro);
    }
}