using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosQueSeraoInativadosUseCase
    {
        Task<PaginacaoResultadoDto<AlunoInativoDto>> Executar(FiltroObterAlunosQueSeraoInativadosDto filtro);
    }
}
