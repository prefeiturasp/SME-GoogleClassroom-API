using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IAtribuirDonoCursoUseCase
    {
        Task<bool> Executar(string email, long turmaId, long componenteCurricularId);
    }
}
