namespace SME.GoogleClassroom.Infra
{
    public class CursoUsuarioInativarDto
    {
        public long CursoUsuarioId { get; set; }
        public long CursoId { get; set; }
        public long UsuarioId { get; set; }
        public string CursoGsaId { get; set; }
        public string UsuarioGsaId { get; set; }
        public string EmailUsuario { get; set; }
    }
}
