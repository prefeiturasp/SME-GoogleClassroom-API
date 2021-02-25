using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCurso
    {
        Task<IEnumerable<Curso>> ObterTodosCursos();

    }
}
