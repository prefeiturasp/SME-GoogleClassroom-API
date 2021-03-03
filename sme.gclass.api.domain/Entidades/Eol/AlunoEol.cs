using System;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoEol
    {

        public AlunoEol(string nomeAluno, DateTime dataNascimento)
        {
            NomeAluno = nomeAluno;
            DataNascimento = dataNascimento;
        }

        public AlunoEol(int codigo, string nomeAluno, string nomeSocial, string organizationPath, DateTime dataNascimento)
        {
            Codigo = codigo;
            NomeAluno = nomeAluno;
            NomeSocial = nomeSocial;
            OrganizationPath = organizationPath;
            DataNascimento = dataNascimento;
        }

        protected AlunoEol()
        {
        }

        public int Codigo { get; set; }
        public string NomeAluno { get; set; }
        public string NomeSocial { get; set; }
        public string Nome { get => ObterNome(); }
        public string OrganizationPath { get; set; }
        public DateTime DataNascimento { get; set; }

        private string _Email;
        public string Email
        {
            get
            {
                if (string.IsNullOrEmpty(_Email))
                    DefinirEmail();

                return _Email;
            }
        }

        public void DefinirEmail(int? tentativa = 0)
        {
            if (!string.IsNullOrEmpty(Nome) && DataNascimento != null)
            {
                string complementoTratativa = "";

                if (tentativa.HasValue)
                {
                    if (tentativa.Value == 1)
                        complementoTratativa = ".";
                    else if (tentativa.Value == 2)
                        complementoTratativa = "_";
                    else if (tentativa.Value == 3)
                        complementoTratativa = "-";
                }


                string[] splitNome = Nome.Split(' ');
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

                _Email = $"{primeiroNome}{iniciaisMeio}{complementoTratativa}{ultimoNome}.{DataNascimento:ddMMyyyy}@edu.sme.prefeitura.sp.gov.br".ToLower();
            }
        }

        private string ObterNome()
        {
            if (string.IsNullOrWhiteSpace(NomeSocial)) return NomeAluno;

            var primeiroNomePessoa = NomeAluno.Split(' ')[0];
            var primeiroNomeSocial = NomeSocial.Split(' ')[0];
            var ultimoNomeSocial = NomeSocial.Replace(primeiroNomeSocial, string.Empty).Trim();

            if (primeiroNomePessoa.Equals(primeiroNomeSocial)) return NomeAluno;
            if (string.IsNullOrWhiteSpace(ultimoNomeSocial)) return NomeAluno;
            return NomeSocial;
        }
    }
}
