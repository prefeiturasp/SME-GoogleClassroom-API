using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSincronizacaoGsaFormacaoCidadeTurmasUseCase
    {
        Task<bool> Executar(string codigoDre, int? componenteCurricularId);
    }
}
