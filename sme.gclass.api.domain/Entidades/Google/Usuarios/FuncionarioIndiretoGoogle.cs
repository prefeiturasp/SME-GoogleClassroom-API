using System;
using System.Text.RegularExpressions;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioIndiretoGoogle
    {
        private const int TamanhoMaximoDoSobrenome = 60;

        public long Indice { get; set; }

        private string cpf;
        public string Cpf 
        {
            get => cpf;
            set => SetCpf(value);
        }

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

        public FuncionarioIndiretoGoogle(string cpf, string nome, string email, string organizationPath)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            OrganizationPath = organizationPath;
            DataInclusao = DateTime.Now;
        }

        protected FuncionarioIndiretoGoogle()
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

        private void SetCpf(string cpf)
        {
            if(!Regex.IsMatch(cpf, "^\\d{11}"))
            {
                throw new NegocioException("O CPF informado é inválido.");
            }

            this.cpf = cpf;
        }
    }
}