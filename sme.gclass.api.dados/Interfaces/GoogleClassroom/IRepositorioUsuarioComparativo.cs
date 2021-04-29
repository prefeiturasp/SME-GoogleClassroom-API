using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioComparativo
    {
        Task<PaginacaoResultadoDto<UsuarioComparativo>> ObterUsuariosComparativosAsync(Paginacao paginacao,  string nome, string email, string organizationPath);
    }
}
