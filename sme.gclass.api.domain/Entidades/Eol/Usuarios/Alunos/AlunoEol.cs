using System;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoEol : UsuarioEol
    {
        public int Codigo { get; set; }
        public DateTime DataNascimento { get; set; }

        public AlunoEol(int codigo, string nomePessoa, string nomeSocial, string organizationPath, DateTime dataNascimento)
            : base(nomePessoa, nomeSocial, organizationPath)
        {
            Codigo = codigo;
            DataNascimento = dataNascimento;
            GerarEmail();
        }

        protected AlunoEol()
        {
        }

        public void DefinirEmail(int? tentativa = 0)
        {
            DefinirComplementoParaTratativaEmail(tentativa);
            GerarEmail();
        }

        private string complementoTratativa = "";
        protected override void GerarEmail()
        {
            if(string.IsNullOrEmpty(Nome) || DataNascimento == default)
            {
                email = null;
                return;
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

            email = $"{primeiroNome}{iniciaisMeio}{complementoTratativa}{ultimoNome}.{DataNascimento:ddMMyyyy}{SufixoEmail}".ToLower();
        }

        private void DefinirComplementoParaTratativaEmail(int? tentativa = 0)
        {
            if (tentativa.HasValue)
            {
                if (tentativa.Value == 1)
                    complementoTratativa = ".";
                else if (tentativa.Value == 2)
                    complementoTratativa = "_";
                else if (tentativa.Value == 3)
                    complementoTratativa = "-";
            }
        }
    }
}
