using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioErro
    {
        Task<long> SalvarAsync(UsuarioErro usuarioErro);
        Task<IEnumerable<UsuarioErro>> ObtemUsuariosErrosPorTipoAsync(UsuarioTipo usuarioTipo);
        Task<int> ExcluirAsync(long usuarioErroId);
    }
}