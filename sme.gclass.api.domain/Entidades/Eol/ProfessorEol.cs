using SME.GoogleClassroom.Infra;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorEol
    {
        public ProfessorEol(long rf, string nome, string organizationPath)
        {
            Rf = rf;
            Nome = nome;
            OrganizationPath = organizationPath;
        }

        protected ProfessorEol()
        { }

        public long Rf { get; set; }
        public string Nome { get; set; }
        public string Email { get => GerarEmail(); }
        public string OrganizationPath { get; set; }

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
