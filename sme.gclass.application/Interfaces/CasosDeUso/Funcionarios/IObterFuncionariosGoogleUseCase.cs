using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterFuncionariosGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioGoogle>> Executar(FiltroObterFuncionariosCadastradosDto filtro);
    }
}