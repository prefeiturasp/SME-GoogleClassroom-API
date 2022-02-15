using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioComponenteCurricularFormacaoCidade : IRepositorioComponenteCurricularFormacaoCidade
    {
        public RepositorioComponenteCurricularFormacaoCidade()
        {}

        public IEnumerable<SalaComponenteModalidadeDto> ObterComponenteCurricular()
        {
            var componentesCurriculares = new List<SalaComponenteModalidadeDto>()
            {
                //new SalaComponenteModalidadeDto() { Id = 7, Nome = "HISTÓRIA"},
                //new SalaComponenteModalidadeDto() { Id = 8, Nome = "GEOGRAFIA"},
                //new SalaComponenteModalidadeDto() { Id = 9, Nome = "LÍNGUA INGLESA"},
                //new SalaComponenteModalidadeDto() { Id = 139, Nome = "ARTE"},
                //new SalaComponenteModalidadeDto() { Id = 89, Nome = "CIÊNCIAS NATURAIS"},
                //new ComponenteCurricularDto() { Id = 138, Nome = "LÍNGUA PORTUGUESA"},
                //new ComponenteCurricularDto() { Id = 2, Nome = "MATEMÁTICA"},
                //new ComponenteCurricularDto() { Id = 2, Nome = "TPA (Informática)"},                
            };

            return componentesCurriculares;
        }

    }
}
