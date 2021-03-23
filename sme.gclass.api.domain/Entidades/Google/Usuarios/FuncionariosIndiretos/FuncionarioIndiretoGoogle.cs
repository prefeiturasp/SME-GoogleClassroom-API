using System.Text.RegularExpressions;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioIndiretoGoogle : UsuarioGoogle
    {
        private string cpf;
        public string Cpf
        {
            get => cpf;
            set => SetCpf(value);
        }
        public override UsuarioTipo UsuarioTipo => UsuarioTipo.FuncionarioIndireto;

        public FuncionarioIndiretoGoogle(string cpf, string nome, string email, string organizationPath)
            : base(nome, email, organizationPath)
        {
            Cpf = cpf;
        }

        protected FuncionarioIndiretoGoogle()
        {
        }

        private void SetCpf(string cpf)
        {
            if (!Regex.IsMatch(cpf, "^\\d{11}"))
            {
                throw new NegocioException("O CPF informado é inválido.");
            }

            this.cpf = cpf;
        }
    }
}