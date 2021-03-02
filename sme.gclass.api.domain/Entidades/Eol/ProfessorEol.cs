using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorEol
    {
        public ProfessorEol(long rf, string nomePessoa, string nomeSocial, string organizationPath)
        {
            Rf = rf;
            NomePessoa = nomePessoa;
            NomeSocial = nomeSocial;
            OrganizationPath = organizationPath;
        }

        protected ProfessorEol()
        { }

        public long Rf { get; set; }
        public string NomePessoa { get; set; }
        public string NomeSocial { get; set; }
        public string Nome { get => ObterNome(); }
        public string Email { get => GerarEmail(); }
        public string OrganizationPath { get; set; }

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

        private string GerarEmail()
        {
            if (!string.IsNullOrEmpty(Nome) && Rf > 0)
            {
                var nomeFormatado = Nome.RemoverAcentosECaracteresEspeciais();
                string[] splitNome = nomeFormatado.Split(' ');
                string primeiroNome = splitNome[0];
                string ultimoNome = "";

                if (splitNome.Length > 1)
                {
                    ultimoNome = splitNome[^1];
                }

                return $"{primeiroNome}{ultimoNome}.{Rf}@edu.sme.prefeitura.sp.gov.br".ToLower();
            }

            return string.Empty;
        }
    }
}