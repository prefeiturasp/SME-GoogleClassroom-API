using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioNota
    {
        Task<long> InserirNota(NotaGsa notaGsa); 
        Task<long> AlterarNota(NotaGsa notaGsa);
        Task<bool> RegistroExiste(string id);
    }
}
