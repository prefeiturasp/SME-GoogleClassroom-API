using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosInativosUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioInativoDto>> Executar(FiltroObterFuncionariosInativosDto filtro);
    }
}
