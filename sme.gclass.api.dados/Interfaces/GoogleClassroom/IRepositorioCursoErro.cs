using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoErro
    {
        Task<long> SalvarAsync(CursoErro dto);
        Task<IEnumerable<CursoErro>> ObterTodos();
        Task Excluir(long id);
        //Task<IEnumerable<CursoErro>> ObterTodosComEmail();
    }
}
