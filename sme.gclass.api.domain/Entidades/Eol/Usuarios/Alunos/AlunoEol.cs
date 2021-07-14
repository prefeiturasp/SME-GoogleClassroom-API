using SME.GoogleClassroom.Infra;
using System;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoEol : UsuarioEol
    {
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

        private const int MaximoTentativasGerarEmail = 3;

        public int Codigo { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TurmaId { get; set; }
        public int SituacaoMatricula { get; set; }

        public void DefinirEmail(int? tentativa = 0)
        {
            if (tentativa.HasValue && tentativa > MaximoTentativasGerarEmail)
                throw new NegocioException("Não foi possível definir um e-mail para o usuário. Máximo de tentivas realizadas.");

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

            email = $"{primeiroNome}{iniciaisMeio}{complementoTratativa}{ultimoNome}.{DataNascimento:ddMMyyyy}{SufixoEmail}".ToLower();
        }

        private void DefinirComplementoParaTratativaEmail(int? tentativa)
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
