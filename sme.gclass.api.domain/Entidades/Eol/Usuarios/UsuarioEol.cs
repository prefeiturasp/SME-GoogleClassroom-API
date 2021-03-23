namespace SME.GoogleClassroom.Dominio
{
    public abstract class UsuarioEol
    {
        protected const string SufixoEmail = "@edu.sme.prefeitura.sp.gov.br";

        public string NomePessoa { get; set; }
        public string NomeSocial { get; set; }
        public string Nome { get => ObterNome(); }

        protected string email;
        public string Email
        {
            get
            {
                if (string.IsNullOrWhiteSpace(email))
                    GerarEmail();

                return email;
            }
        }

        public string OrganizationPath { get; set; }

        public UsuarioEol(string nomePessoa, string nomeSocial, string organizationPath)
            :this(nomePessoa, organizationPath)
        {
            NomeSocial = nomeSocial;
        }

        public UsuarioEol(string nomePessoa, string organizationPath)
        {
            NomePessoa = nomePessoa;
            OrganizationPath = organizationPath;
        }

        protected UsuarioEol()
        {
        }

        private string ObterNome()
        {
            if (string.IsNullOrWhiteSpace(NomeSocial)) return NomePessoa;

            var primeiroNomePessoa = NomePessoa.Split(' ')[0];
            var primeiroNomeSocial = NomeSocial.Split(' ')[0];
            var ultimoNomeSocial = NomeSocial.Replace(primeiroNomeSocial, string.Empty).Trim();

            if (primeiroNomePessoa.Equals(primeiroNomeSocial)) return NomePessoa;
            if (string.IsNullOrWhiteSpace(ultimoNomeSocial)) return NomePessoa;
            return NomeSocial;
        }

        protected abstract void GerarEmail();
    }
}