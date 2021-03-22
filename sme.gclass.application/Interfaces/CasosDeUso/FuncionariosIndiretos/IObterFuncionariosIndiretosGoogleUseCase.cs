using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosIndiretosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>> Executar(FiltroObterFuncionariosIndiretosCadastradosDto filtro);
    }
}