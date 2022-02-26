using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IProcessarUsuarioGsaErroUseCase
    {
        Task<bool> Executar();
    }
}