using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioEmailDto
    {
        public UsuarioTipo UsuarioTipo { get; set; }
        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}