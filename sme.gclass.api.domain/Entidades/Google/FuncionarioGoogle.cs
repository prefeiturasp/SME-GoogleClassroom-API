using System;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioGoogle
    {
        public long Rf { get; set; }
        public string Nome { get; set; }
        public string PrimeiroNome 
        { 
            get
            {
                if (string.IsNullOrWhiteSpace(Nome)) return string.Empty;
                return Nome.Split(' ')[0];
            }
        }

        public string Sobrenome
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Nome)) return string.Empty;
                return Nome.Replace(PrimeiroNome, "").Trim();
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
    }
}