using System;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoEol
    {

        public AlunoEol(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public AlunoEol(int codigo, string nome, string nomeSocial, string caminhoOrganizacao, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            NomeSocial = nomeSocial;
            CaminhoOrganizacao = caminhoOrganizacao;
            DataNascimento = dataNascimento;
        }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string NomeSocial { get; set; }

        public string CaminhoOrganizacao { get; set; }

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

        public string NomeValido => !string.IsNullOrEmpty(NomeSocial) ? NomeSocial : Nome;

        public void DefinirEmail(int? tentativa = 0)
        {

            if (!string.IsNullOrEmpty(NomeValido) && DataNascimento != null)
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


                string[] splitNome = NomeValido.Split(' ');
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
    }
}
