namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioCursoGsa
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }

        public UsuarioCursoGsa(string usuarioId, string cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }
    }
}