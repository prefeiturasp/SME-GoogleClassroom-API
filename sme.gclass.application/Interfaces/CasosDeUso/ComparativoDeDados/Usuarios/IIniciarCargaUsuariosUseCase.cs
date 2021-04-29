using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarCargaUsuariosUseCase
    {
        Task<bool> Executar();
    }
}
