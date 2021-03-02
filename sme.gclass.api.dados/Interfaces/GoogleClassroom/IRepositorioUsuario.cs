using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuario
    {
        Task<PaginacaoResultadoDto<AlunoGoogle>> ObterAlunosAsync(Paginacao paginacao);
        Task<bool> ExisteAlunoPorRf(long rf);
        Task<string> ObterEmailUsuarioPorTipo(string email, int usuarioTipo);
        Task<PaginacaoResultadoDto<FuncionarioGoogle>> ObterFuncionariosAsync(Paginacao paginacao);
        Task<PaginacaoResultadoDto<ProfessorGoogle>> ObterProfessoresAsync(Paginacao paginacao);
        Task<IEnumerable<FuncionarioGoogle>> ObterFuncionariosPorRfs(long[] rfs);
        Task<bool> ExisteFuncionarioPorRf(long rf);
        Task<IEnumerable<ProfessorGoogle>> ObterProfessoresPorRfs(long[] rfs);
        Task<bool> ExisteProfessorPorRf(long rf);
        Task<long> SalvarAsync(long id, string nome, string email, UsuarioTipo tipo, string organizationPath, DateTime dataInclusao, DateTime? dataAtualizacao);
    }
}
