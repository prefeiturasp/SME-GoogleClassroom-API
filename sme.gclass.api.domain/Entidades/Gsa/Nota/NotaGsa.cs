using System;

namespace SME.GoogleClassroom.Dominio
{
    public class NotaGsa
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public string UsuarioGsaId { get; set; }
        public string situacao { get; set; }
        public double? Nota { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
