using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterGradesDeCursosDto : FiltroPaginacaoBaseDto
    {
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }

        [Required]
        [DefaultValue("2021-02-20")]
        public DateTime DataReferencia { get; set; }
    }
}
