using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioComparativo
    {
        Task<int> ValidarCursosExistentesCursosComparativosAsync();
    }
}
