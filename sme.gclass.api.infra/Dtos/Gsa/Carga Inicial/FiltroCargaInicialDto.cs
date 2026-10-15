using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaInicialDto
    {
        /// <summary>Ano letivo da carga. Nulo = ano atual.</summary>
        [Range(1, 9999)]
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }

        public FiltroCargaInicialDto()
        {
        }

        public FiltroCargaInicialDto(int? anoLetivo, IList<int> tiposUes, IList<long> ues, IList<long> turmas)
        {
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes == null ? null : new List<int>(tiposUes);
            Ues = ues == null ? null : new List<long>(ues);
            Turmas = turmas == null ? null : new List<long>(turmas);
        }
    }
}
