namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioIndiretoEol : UsuarioEol
    {
        public FuncionarioIndiretoEol(string cpf, string nomePessoa, string nomeSocial, string organizationPath)
            :base(nomePessoa, nomeSocial, organizationPath)
        {
            Cpf = cpf;
            GerarEmail();
        }

        protected FuncionarioIndiretoEol()
        { }

        public string Cpf { get; set; }

        protected override void GerarEmail()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Cpf))
            {
                email = null;
                return;
            }

            var nomeFormatado = Nome.RemoverAcentosECaracteresEspeciais();
            string[] splitNome = nomeFormatado.Split(' ');
            string primeiroNome = splitNome[0];
            string ultimoNome = "";

            if (splitNome.Length > 1)
            {
                ultimoNome = splitNome[^1];
            }

            email = $"{primeiroNome}{ultimoNome}.{Cpf}{SufixoEmail}".ToLower();
        }
    }
}