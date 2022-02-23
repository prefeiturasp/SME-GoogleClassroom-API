using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IAtribuirDonoCursoFormacaoCidadeUseCase
    {
        Task<bool> Executar(string email, string salaVirtual);
    }
}
