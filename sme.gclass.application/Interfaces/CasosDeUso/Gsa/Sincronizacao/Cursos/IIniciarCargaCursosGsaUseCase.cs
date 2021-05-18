using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarCargaCursosGsaUseCase
    {
        Task<bool> Executar();
    }
}