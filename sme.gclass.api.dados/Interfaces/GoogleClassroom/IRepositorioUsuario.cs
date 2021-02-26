using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<UsuarioDto>> ObterFuncionarios(UsuarioTipo usuarioTipo, Paginacao paginacao);
    }
}