using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioEmailDto
    {
        public UsuarioTipo Tipo { get; set; }
        public long? Id { get; set; }
        public string? Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public bool UsuarioExterno()
        {
            return Id.EhNulo() && Cpf.NaoEhNulo();
        }

        public bool EhAluno()
        {
            return Tipo == UsuarioTipo.Aluno;
        }

        public bool EhFuncionario()
        {
            return (Tipo == UsuarioTipo.Professor) || (Tipo == UsuarioTipo.Funcionario);
        }
    }
}