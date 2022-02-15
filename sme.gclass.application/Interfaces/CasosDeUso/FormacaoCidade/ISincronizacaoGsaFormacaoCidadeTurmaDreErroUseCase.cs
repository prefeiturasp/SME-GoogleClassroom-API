using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaDreErroUseCase
    {
        Task<bool> Executar();
    }
}