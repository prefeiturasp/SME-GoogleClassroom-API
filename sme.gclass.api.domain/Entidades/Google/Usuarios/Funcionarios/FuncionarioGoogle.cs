namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioGoogle : UsuarioGoogle
    {
        public long Rf { get; set; }
        public override UsuarioTipo UsuarioTipo => UsuarioTipo.Funcionario;

        public FuncionarioGoogle(long rf, string nome, string email, string organizationPath)
            : base(nome, email, organizationPath)
        {
            Rf = rf;
        }

        protected FuncionarioGoogle()
        {
        }
    }
}