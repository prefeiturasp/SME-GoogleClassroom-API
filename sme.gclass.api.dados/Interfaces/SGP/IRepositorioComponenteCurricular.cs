using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioComponenteCurricular
    {
        Task<bool> LancaNota(long componenteCurricularId);
    }
}
