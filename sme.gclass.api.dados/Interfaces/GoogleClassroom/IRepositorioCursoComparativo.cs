using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoComparativo
    {
        Task<long> SalvarAsync(CursoComparativo cursoComparativo);
        Task<int> ValidarCursosExistentesCursosComparativosAsync();
    }
}
