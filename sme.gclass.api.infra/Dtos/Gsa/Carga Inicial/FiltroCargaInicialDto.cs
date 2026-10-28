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
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }

        public FiltroCargaInicialDto(int anoLetivo, IList<int> tiposUes, IList<long> ues, IList<long> turmas)
        {
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes != null ? new List<int>(tiposUes) : new List<int>();
            Ues = ues != null ? new List<long>(ues) : new List<long>();
            Turmas = turmas != null ? new List<long>(turmas) : new List<long>();
        }
    }
}
