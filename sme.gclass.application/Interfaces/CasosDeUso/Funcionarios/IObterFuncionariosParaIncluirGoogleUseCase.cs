using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioEol>> Executar(FiltroObterFuncionariosIncluirGoogleDto filtro);
    }
}