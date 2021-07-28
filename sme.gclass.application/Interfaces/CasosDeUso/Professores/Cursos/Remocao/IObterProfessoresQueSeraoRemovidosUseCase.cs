using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterProfessoresQueSeraoRemovidosUseCase
    {
        Task<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>> Executar(FiltroObterProfessoresQueSeraoRemovidosDto filtro);
    }
}
