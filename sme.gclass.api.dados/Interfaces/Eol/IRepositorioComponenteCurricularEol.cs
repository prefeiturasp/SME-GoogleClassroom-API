using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.Pedagogico.Interface.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioComponenteCurricularEol
    {
        Task<IEnumerable<ComponenteCurricularEol>> ObterDisciplinasAsync();
        Task<IEnumerable<DisciplinaTerritorioSaberDTO>> ObterDisciplinaTerritorioDosSaberesAsync(string codigoTurma, IEnumerable<long> codigosComponentesCurriculares);
        Task<IEnumerable<AgrupamentoAtribuicaoTerritorioSaber>> ObterAgrupamentosTerritorioSaber(long codigoTurma,
                                                                                                 long? codigoTerritorioSaber,
                                                                                                 long? codigoExperienciaPegagogica,
                                                                                                 long? codigoComponenteCurricular = null,
                                                                                                 DateTime? dataBase = null,
                                                                                                 DateTime? dataInicio = null,
                                                                                                 string rfProfessor = null,
                                                                                                 string codigosComponentesCurriculares = null,
                                                                                                 bool? encerramentoAtribuicaoViaAtualizacaoComponentesAgrupados = null);
        Task<IEnumerable<ComponenteCurricularTerritorioAtribuidoTurmaDTO>> ObterComponentesCurricularesTerritorioAtribuidos(long codigoTurma, string rfProf = null);
    }
}
