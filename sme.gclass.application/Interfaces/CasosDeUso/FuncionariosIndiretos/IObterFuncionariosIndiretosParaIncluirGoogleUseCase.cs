using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosIndiretosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Executar(FiltroObterFuncionariosIndiretosIncluirGoogleDto filtro);
    }
}