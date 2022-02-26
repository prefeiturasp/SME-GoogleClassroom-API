using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaCursoErroUseCase
    {
        Task<bool> Executar();
    }
}