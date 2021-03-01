using System;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string CaminhoOrganizacao { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(Nome) && DataNascimento != null)
                {
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

                    return $"{primeiroNome}{iniciaisMeio}{ultimoNome}.{DataNascimento:ddMMyyyy}@edu.sme.prefeitura.sp.gov.br".ToLower();
                }

                return string.Empty;

            }
        }
    }
}
