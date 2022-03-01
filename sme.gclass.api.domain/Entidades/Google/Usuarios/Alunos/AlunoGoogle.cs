namespace SME.GoogleClassroom.Dominio
{
    public class AlunoGoogle : UsuarioGoogle
    {
        public int Codigo { get; set; }
        public override UsuarioTipo UsuarioTipo => UsuarioTipo.Aluno;

        public string MensagemErro { get; set; }

        public AlunoGoogle(int codigo, string nome, string email, string organizationPath)
            : base(nome, email, organizationPath)
        {
            Codigo = codigo;
        }

        protected AlunoGoogle()
        {
        }
    }
}