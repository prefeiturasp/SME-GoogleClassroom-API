using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaAlunoErroUseCase
    {
        Task<bool> Executar();
    }
}