namespace SME.GoogleClassroom.Infra
{
    public class NotaGsaDto
    {
        public NotaGsaDto(long id, long usuarioId, string statusNota, double? nota)
        {
            Id = id;
            UsuarioId = usuarioId;
            Nota = nota;
            StatusNota = statusNota;
        }

        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string StatusNota { get; set; }
        public double? Nota { get; set; }
    }
}
