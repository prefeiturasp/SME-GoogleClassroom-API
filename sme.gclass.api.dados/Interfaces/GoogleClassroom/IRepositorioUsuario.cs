using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<UsuarioDto>> ObterFuncionariosAsync(Paginacao paginacao);


        
        
        Task<IEnumerable<UsuarioDto>> ObterProfessoresPorRfs(long[] rfs);
        Task<bool> ExisteProfessorPorRf(long rf);
    }
}