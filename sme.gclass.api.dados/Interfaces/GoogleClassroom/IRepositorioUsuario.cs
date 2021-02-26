using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<UsuarioDto>> ObterUsuarios(UsuarioTipo usuarioTipo, Paginacao paginacao);
    }
}