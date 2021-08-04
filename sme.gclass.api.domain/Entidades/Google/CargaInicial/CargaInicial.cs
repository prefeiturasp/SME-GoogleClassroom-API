using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CargaInicial
    {
        public long Id { get; set; }
        public int Ano { get; set; }
        public string TiposUe { get; set; }
        public string Ues { get; set; }
        public string Turmas { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
