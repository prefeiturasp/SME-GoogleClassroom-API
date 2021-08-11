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

        public bool PossuiTiposUe() => !string.IsNullOrEmpty(TiposUe?.Trim());
        public bool PossuiUes() => !string.IsNullOrEmpty(Ues?.Trim());
        public bool PossuiTurmas() => !string.IsNullOrEmpty(Turmas?.Trim());
    }
}
