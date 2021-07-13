using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioAtividade
    {
        Task<long> AlterarAtividade(AtividadeGsa atividadeGsa);
        Task<long> InserirAtividade(AtividadeGsa atividadeGsa);
        Task<bool> RegistroExiste(long id);
    }
}
