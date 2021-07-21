namespace SME.GoogleClassroom.Infra
{
    public class AlunoUsuarioInativarDto
    {
        public long UsuarioId { get; set; }
        public long UsuarioGsaId { get; set; }
        public string EmailUsuario { get; set; }

        public AlunoUsuarioInativarDto(long usuarioId, long usuarioGsaId, string emailUsuario)
        {
            UsuarioId = usuarioId;
            UsuarioGsaId = usuarioGsaId;
            EmailUsuario = emailUsuario;
        }
    }
}
