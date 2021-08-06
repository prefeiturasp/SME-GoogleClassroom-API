
namespace SME.GoogleClassroom.Infra
{
    public class ProfessorInativoDto
    {
        public long UsuarioId { get; set; }
        public long UsuarioGsaId { get; set; }
        public int UsuarioTipo { get; set; }
        public string EmailUsuario { get; set; }

        public ProfessorInativoDto(long usuarioId, long usuarioGsaId, string emailUsuario, int usuarioTipo)
        {
            UsuarioId = usuarioId;
            UsuarioGsaId = usuarioGsaId;
            EmailUsuario = emailUsuario;
            UsuarioTipo = usuarioTipo;
        }
    }
}
