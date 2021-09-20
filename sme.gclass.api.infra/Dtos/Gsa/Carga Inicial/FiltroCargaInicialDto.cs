using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaInicialDto
    {
        [Required(ErrorMessage = "Informe o ano letivo")]
        [Range(1, 9999)]
        public int AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }

        public FiltroCargaInicialDto()
        {
        }

        public FiltroCargaInicialDto(int anoLetivo, IList<int> tiposUes, IList<long> ues, IList<long> turmas)
        {
            AnoLetivo = anoLetivo;
            TiposUes = new List<int>(tiposUes);
            Ues = new List<long>(ues);
            Turmas = new List<long>(turmas);
        }
    }
}
