using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosParaCadastrarUseCase
    {
        Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosIncluirGoogleDto filtro);
    }
}