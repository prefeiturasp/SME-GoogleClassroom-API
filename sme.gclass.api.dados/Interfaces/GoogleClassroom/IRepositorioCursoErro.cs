using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoErro
    {
        Task<long> SalvarAsync(CursoErroDto dto);
    }
}
