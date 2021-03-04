using System;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioGoogle
    {
        private const int TamanhoMaximoDoSobrenome = 60;

        public long Indice { get; set; }
        public long Rf { get; set; }

        private string nome;
        public string Nome
        {
            get => nome;
            set => SetNome(value);
        }

        public string PrimeiroNome 
        { 
            get
            {
                if (string.IsNullOrWhiteSpace(nome)) return string.Empty;
                return nome.Split(' ')[0];
            }
        }

        public string Sobrenome
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome)) return string.Empty;
                return nome.Replace(PrimeiroNome, "").Trim();
            }
        }

        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public FuncionarioGoogle(long rf, string nome, string email, string organizationPath)
        {
            Rf = rf;
            Nome = nome;
            Email = email;
            OrganizationPath = organizationPath;
            DataInclusao = DateTime.Now;
        }

        protected FuncionarioGoogle()
        {
        }

        private void SetNome(string nome)
        {
            this.nome = nome;
            if (Sobrenome.Length <= TamanhoMaximoDoSobrenome)
                return;

            var sobrenomeTrucado = Sobrenome.Substring(0, TamanhoMaximoDoSobrenome);
            var nomeFormatado = nome.Replace(Sobrenome, sobrenomeTrucado).Trim(); ;
            this.nome = nomeFormatado;
        }
    }
}