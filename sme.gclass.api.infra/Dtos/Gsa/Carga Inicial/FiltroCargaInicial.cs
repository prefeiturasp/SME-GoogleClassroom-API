using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial
{
    public class FiltroCargaInicial
    {
        public int Ano { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
    }
}
