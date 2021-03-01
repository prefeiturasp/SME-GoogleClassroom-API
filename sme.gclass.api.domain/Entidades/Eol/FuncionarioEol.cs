using SME.GoogleClassroom.Infra;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioEol
    {
        public FuncionarioEol(long rf, string nome, string organizationPath)
        {
            Rf = rf;
            Nome = nome;
            OrganizationPath = organizationPath;
        }

        protected FuncionarioEol()
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
                string ultimoNome = "", iniciaisMeio = "";

                if (splitNome.Length > 1)
                {
                    ultimoNome = splitNome[^1];

                    if (splitNome.Length > 2)
                    {
                        for (int i = 1; i < splitNome.Length - 1; i++)
                        {
                            string elemento = splitNome[i].ToLower();

                            if (!(new string[] { "da", "das", "de", "do", "dos", "os" }).Contains(elemento))
                                iniciaisMeio += elemento.Substring(0, 1);
                        }
                    }
                }

                return $"{primeiroNome}{iniciaisMeio}{ultimoNome}.{Rf}@edu.sme.prefeitura.sp.gov.br".ToLower();
            }

            return string.Empty;
        }
    }
}