using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarValidacaoCursosGsaUseCase
    {
        Task<bool> Executar();
    }
}