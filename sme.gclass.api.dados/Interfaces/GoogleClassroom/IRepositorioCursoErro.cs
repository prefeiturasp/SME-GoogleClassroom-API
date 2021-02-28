using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoErro
    {
        Task<long> SalvarAsync(CursoErro dto);
    }
}
