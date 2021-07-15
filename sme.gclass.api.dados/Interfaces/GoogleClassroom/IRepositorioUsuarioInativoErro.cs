using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioUsuarioInativoErro
    {
        Task<long> SalvarAsync(UsuarioInativoErro alunoInativoErro);
    }
}