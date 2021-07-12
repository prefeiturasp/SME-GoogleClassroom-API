using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoInativacaoUsuariosCursosGsaUseCase
    {
        Task<bool> Executar();
    }
}
