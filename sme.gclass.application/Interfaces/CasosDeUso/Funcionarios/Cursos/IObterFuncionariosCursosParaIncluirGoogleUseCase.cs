using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosCursosParaIncluirGoogleUseCase
    {
        Task<IEnumerable<FuncionarioCursoEol>> Executar(long rf);
    }
}