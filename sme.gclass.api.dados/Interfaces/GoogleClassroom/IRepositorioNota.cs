using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioNota
    {
        Task<long> InserirNota(NotaGsa notaGsa); 
        Task<long> AlterarNota(NotaGsa atividadeGsa);
        Task<bool> RegistroExiste(long id);
    }
}
