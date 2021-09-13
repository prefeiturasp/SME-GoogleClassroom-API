using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaInicialDto : ParametrosCargaInicialDto
    {
        [Required]
        public int AnoLetivo { get; set; }
    }
}
