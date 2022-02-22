using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaSmeDreErroUseCase
    {
        Task<bool> Executar();
    }
}