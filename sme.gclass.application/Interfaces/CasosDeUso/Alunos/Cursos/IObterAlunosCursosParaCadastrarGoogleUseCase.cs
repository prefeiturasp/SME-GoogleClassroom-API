using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterAlunosCursosParaCadastrarGoogleUseCase
    {
        Task<IEnumerable<AlunoCursoEol>> Executar(long codigoAluno);
    }
}