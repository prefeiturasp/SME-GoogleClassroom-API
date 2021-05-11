namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioCursoGsa
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }
        public UsuarioCursoGsaTipo UsuarioCursoTipo { get; set; }

        public UsuarioCursoGsa(string usuarioId, string cursoId, UsuarioCursoGsaTipo usuarioCursoTipo)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            UsuarioCursoTipo = usuarioCursoTipo;
        }
    }
}