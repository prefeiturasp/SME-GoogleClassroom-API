using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioCursoUsuarioErro
    {
        Task<long> SalvarAsync(CursoUsuarioErro cursoUsuarioErro);
    }
}