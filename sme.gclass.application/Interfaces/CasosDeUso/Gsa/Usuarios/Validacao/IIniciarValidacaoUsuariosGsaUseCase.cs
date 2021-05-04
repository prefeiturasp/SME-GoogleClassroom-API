using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarValidacaoUsuariosGsaUseCase
    {
        Task<bool> Executar();
    }
}