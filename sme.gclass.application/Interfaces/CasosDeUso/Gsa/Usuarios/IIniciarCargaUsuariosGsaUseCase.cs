using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarCargaUsuariosGsaUseCase
    {
        Task<bool> Executar();
    }
}
