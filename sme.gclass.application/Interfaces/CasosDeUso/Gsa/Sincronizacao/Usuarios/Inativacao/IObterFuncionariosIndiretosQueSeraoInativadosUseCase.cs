using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosIndiretosQueSeraoInativadosUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Executar(FiltroObterFuncionariosIndiretosQueSeraoInativadosDto filtro);
    }
}
