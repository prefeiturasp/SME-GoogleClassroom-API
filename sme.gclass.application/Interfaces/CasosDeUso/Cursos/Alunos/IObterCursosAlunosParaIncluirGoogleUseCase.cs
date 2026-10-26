using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosAlunosParaIncluirGoogleUseCase
    {
        Task<IEnumerable<AlunoCursoParaIncluirGoogleDto>> Executar(long turmaId, long componenteCurricularId);
    }
}