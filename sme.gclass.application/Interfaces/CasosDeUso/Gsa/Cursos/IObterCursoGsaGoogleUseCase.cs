using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursoGsaGoogleUseCase
    {
        Task<ConsultaCursoGsaDto> Executar(long turmaId, long componenteCurricularId);
    }
}
