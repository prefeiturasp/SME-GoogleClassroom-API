using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoUsuario
    {
        Task<bool> ExisteProfessorCurso(long usuarioId, long cursoId);
        Task<long> SalvarAsync(CursoUsuario cursoUsuario);
    }
}