using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioGsa
    {
        Task<int> ValidarUsuariosExistentesUsuariosComparativosAsync();
        Task<PaginacaoResultadoDto<UsuarioGsa>> ObterUsuariosComparativosAsync(Paginacao paginacao,  string nome, string email, string organizationPath);
        Task<bool> SalvarAsync(UsuarioGsa usuarioComparativo);
    }
}
