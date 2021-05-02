using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarValidarUsuariosExistentesUsuariosGsaUseCase
    {
        Task<bool> Executar();
    }
}
