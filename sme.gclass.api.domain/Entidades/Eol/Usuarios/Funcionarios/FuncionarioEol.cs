namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioEol : UsuarioEol
    {
        public FuncionarioEol(long rf, string nomePessoa, string nomeSocial, string organizationPath)
            :base(nomePessoa, nomeSocial, organizationPath)
        {
            Rf = rf;
            GerarEmail();
        }

        protected FuncionarioEol()
        { }

        public long Rf { get; set; }

        protected override void GerarEmail()
        {
            if (string.IsNullOrEmpty(Nome) || Rf <= 0)
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

            email = $"{primeiroNome}{ultimoNome}.{Rf}{SufixoEmail}".ToLower();
        }
    }
}