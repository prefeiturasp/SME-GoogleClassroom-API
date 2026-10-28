using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterAlunosCursosParaCadastrarGoogleUseCase
    {
        Task<IEnumerable<CursoAlunoParaCadastrarDto>> Executar(long codigoAluno);
    }
}
