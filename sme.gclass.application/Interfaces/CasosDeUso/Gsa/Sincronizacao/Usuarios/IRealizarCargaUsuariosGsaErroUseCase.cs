using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IRealizarCargaUsuariosGsaErroUseCase
    {
        Task<bool> Executar();
    }
}