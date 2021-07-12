using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosQueSeraoRemovidosUseCase
    {
        Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosQueSeraoRemovidosDto filtro);
    }
}
