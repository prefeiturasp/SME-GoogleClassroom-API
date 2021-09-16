namespace SME.GoogleClassroom.Infra
{
    public class UsuarioCursoGoogleDto
    {
        public UsuarioCursoGoogleDto(long cursoId, string usuarioId, int tipoGsa)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
            TipoGsa = tipoGsa;
        }

        public long CursoId { get; set; }
        public string UsuarioId { get; set; }
        public int TipoGsa { get; }
    }
}
