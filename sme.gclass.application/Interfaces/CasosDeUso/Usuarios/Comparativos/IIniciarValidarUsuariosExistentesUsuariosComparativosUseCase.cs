using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarValidarUsuariosExistentesUsuariosComparativosUseCase
    {
        Task<bool> Executar();
    }
}
