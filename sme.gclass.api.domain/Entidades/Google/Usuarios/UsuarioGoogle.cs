using System;

namespace SME.GoogleClassroom.Dominio
{
    public abstract class UsuarioGoogle
    {
        private const int TamanhoMaximoDoSobrenome = 60;

        public long Indice { get; set; }

        private string googleClassroomId;
        public string GoogleClassroomId 
        {
            get => googleClassroomId;
            set => SetGoogleClassroomId(value);
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
                return nome.Replace(PrimeiroNome, string.Empty).Trim();
            }
        }

        public abstract UsuarioTipo UsuarioTipo { get; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public UsuarioGoogle(string nome, string email, string organizationPath)
        {
            Nome = nome;
            Email = email;
            OrganizationPath = organizationPath;
            DataInclusao = DateTime.Now;
        }

        protected UsuarioGoogle()
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

        private void SetGoogleClassroomId(string googleClassroomId)
        {
            if (string.IsNullOrWhiteSpace(googleClassroomId))
                throw new NegocioException($"O identificador do usuário {nome} no Google Classroom informado é inválido.");

            this.googleClassroomId = googleClassroomId;
        }
    }
}