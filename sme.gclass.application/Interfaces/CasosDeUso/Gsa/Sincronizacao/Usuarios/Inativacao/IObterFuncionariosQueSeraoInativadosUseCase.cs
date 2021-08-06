using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosQueSeraoInativadosUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioEol>> Executar(FiltroObterFuncionariosQueSeraoInativadosDto filtro);
    }
}
