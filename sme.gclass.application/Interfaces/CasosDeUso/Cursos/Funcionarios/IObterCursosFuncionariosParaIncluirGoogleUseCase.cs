using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosFuncionariosParaIncluirGoogleUseCase
    {
        Task<IEnumerable<FuncionarioCursoParaIncluirGoogleDto>> Executar(long turmaId, long componenteCurricularId);
    }
}