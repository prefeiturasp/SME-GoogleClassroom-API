namespace SME.GoogleClassroom.Infra
{
    public class CursoUsuarioRemoverDto
    {
        public long CursoUsuarioId { get; set; }
        public long CursoId { get; set; }
        public long UsuarioId { get; set; }
        public string CursoGsaId { get; set; }
        public string UsuarioGsaId { get; set; }
        public string EmailUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public int TipoGsa { get; set; }
    }
}
