using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosAlunosParaIncluirGoogleUseCase
    {
        Task<IEnumerable<AlunoCursoEol>> Executar(long turmaId, long componenteCurricularId);
    }
}