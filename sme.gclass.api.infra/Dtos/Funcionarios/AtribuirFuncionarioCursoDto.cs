using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class AtribuirFuncionarioCursoDto
    {
        [Required]
        public long Rf { get; set; }

        [Required]
        public long TurmaId { get; set; }

        [Required]
        public long ComponenteCurricularId { get; set; }
    }
}
