using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAtribuicoesDeCursosDosProfessoresUseCase
    {
        Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEolDto>> Executar(FiltroObterAtribuicoesDeCursosDosProfessoresDto filtro);
    }
}