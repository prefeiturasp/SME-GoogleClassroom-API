using SME.GoogleClassroom.Dominio;
using SME.Pedagogico.Interface.DTO.RetornoQueryDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioComponenteCurricularEol
    {
        Task<IEnumerable<ComponenteCurricularEol>> ObterDisciplinasAsync();
        Task<IEnumerable<DisciplinaTerritorioSaberDTO>> ObterDisciplinaTerritorioDosSaberesAsync(string codigoTurma, IEnumerable<long> codigosComponentesCurriculares);
    }
}
