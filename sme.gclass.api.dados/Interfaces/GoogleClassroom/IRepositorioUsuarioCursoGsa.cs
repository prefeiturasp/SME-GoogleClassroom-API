using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioCursoGsa
    {
        Task<bool> ExistePorUsuarioIdCursoIdAsync(string usuarioId, string cursoId);

        Task<bool> SalvarAsync(UsuarioCursoGsa usuarioCursoGsa);
    }
}