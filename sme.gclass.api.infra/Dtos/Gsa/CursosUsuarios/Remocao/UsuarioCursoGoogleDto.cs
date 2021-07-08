namespace SME.GoogleClassroom.Infra
{
    public class UsuarioCursoGoogleDto
    {
        public UsuarioCursoGoogleDto(string cursoId, string usuarioId)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }

        public string CursoId { get; set; }
        public string UsuarioId { get; set; }
    }
}
