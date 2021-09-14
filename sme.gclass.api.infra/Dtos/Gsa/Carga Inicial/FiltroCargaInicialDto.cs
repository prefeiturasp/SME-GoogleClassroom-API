using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial
{
    public class FiltroCargaInicialDto
    {
        public int AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
    }
}
