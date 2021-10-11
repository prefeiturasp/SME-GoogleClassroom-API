using System;

namespace SME.GoogleClassroom.Infra
{
    public class NotaGsaDto
    {
        public NotaGsaDto(string id, string usuarioId, string statusNota, double? nota, DateTime? dataInclusao, DateTime? dataAlteracao = null)
        {
            Id = id;
            UsuarioId = usuarioId;
            Nota = nota;
            DataInclusao = dataInclusao ?? DateTime.Now;
            DataAlteracao = dataAlteracao;
            StatusNota = statusNota;
        }

        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string StatusNota { get; set; }
        public double? Nota { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
