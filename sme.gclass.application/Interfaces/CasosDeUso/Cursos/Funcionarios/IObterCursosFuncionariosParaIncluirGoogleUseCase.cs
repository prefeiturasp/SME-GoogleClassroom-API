using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosFuncionariosParaIncluirGoogleUseCase
    {
        Task<IEnumerable<FuncionarioCursoEol>> Executar(long turmaId, long componenteCurricularId);
    }
}