namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioCurso
    {
        public long CursoUsuarioId { get; set; }
        public long UsuarioId { get; set; }
        public string UsuarioGsaId { get; set; }
        
        public string Email { get; set; }

        public FuncionarioCurso()
        {
        }

        public FuncionarioCurso(long cursoUsuarioId, long usuarioId, string usuarioGsaId, string email)
        {
            CursoUsuarioId = cursoUsuarioId;
            UsuarioId = usuarioId;
            UsuarioGsaId = usuarioGsaId;
            Email = email;
        }
    }
    
    
}