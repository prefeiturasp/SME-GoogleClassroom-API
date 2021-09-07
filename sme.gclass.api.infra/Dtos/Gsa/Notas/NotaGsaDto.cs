namespace SME.GoogleClassroom.Infra
{
    public class NotaGsaDto
    {
        public NotaGsaDto(string id, string usuarioId, string statusNota, double? nota)
        {
            Id = id;
            UsuarioId = usuarioId;
            Nota = nota;
            StatusNota = statusNota;
        }

        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string StatusNota { get; set; }
        public double? Nota { get; set; }
    }
}
