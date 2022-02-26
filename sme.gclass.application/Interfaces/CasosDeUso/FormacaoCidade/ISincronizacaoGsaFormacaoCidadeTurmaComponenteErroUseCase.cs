using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaComponenteErroUseCase
    {
        Task<bool> Executar();
    }
}