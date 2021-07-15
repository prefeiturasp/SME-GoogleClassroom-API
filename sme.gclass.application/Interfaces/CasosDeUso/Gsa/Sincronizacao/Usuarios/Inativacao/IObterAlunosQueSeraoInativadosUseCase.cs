using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosQueSeraoInativadosUseCase
    {
        Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosQueSeraoInativadosDto filtro);
    }
}
