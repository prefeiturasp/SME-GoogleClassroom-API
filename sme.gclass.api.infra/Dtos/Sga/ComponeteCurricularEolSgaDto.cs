using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ComponeteCurricularEolSgaDto
    {
        public long ComponenteCodigo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ProfessorEolSgaDto> Professores { get; set; }
    }
}