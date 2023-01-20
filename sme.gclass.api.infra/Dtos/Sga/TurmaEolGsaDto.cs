using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class TurmaEolGsaDto
    {
        public long TurmaCodigo { get; set; }
        public string TumaAnoModalidade { get; set; }
        public string NomeAno { get; set; }
        public string TurmaNome { get; set; }
        public IEnumerable<ComponeteCurricularEolSgaDto> ComponentesCurriculares { get; set; }
    }
}