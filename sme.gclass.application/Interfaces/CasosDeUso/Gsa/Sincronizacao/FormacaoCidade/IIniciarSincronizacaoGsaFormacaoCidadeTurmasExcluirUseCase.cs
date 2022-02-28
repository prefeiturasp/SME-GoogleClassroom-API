using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase
    {
        Task<bool> Executar(long[] cursosIds);
    }
}
