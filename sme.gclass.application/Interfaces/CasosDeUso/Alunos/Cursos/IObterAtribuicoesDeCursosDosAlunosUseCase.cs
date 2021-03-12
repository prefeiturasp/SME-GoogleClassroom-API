using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAtribuicoesDeCursosDosAlunosUseCase
    {
        Task<PaginacaoResultadoDto<AtribuicaoAlunoCursoEolDto>> Executar(FiltroObterAtribuicoesDeCursosDosAlunosDto filtro);
    }
}