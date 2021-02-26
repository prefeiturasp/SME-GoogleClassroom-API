using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioDto>> Executar(int registrosQuantidade, int paginaNumero);
    }
}