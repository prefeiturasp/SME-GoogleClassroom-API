using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoCadastradoDto
    {
        private long id;
        public long Id
        {
            get => id;
            set
            {
                id = value;
                if (codigo == 0) codigo = value;
            }
        }

        private long codigo;
        public long Codigo
        {
            get => codigo != 0 ? codigo : id;
            set
            {
                codigo = value;
                if (id == 0) id = value;
            }
        }

        public long Indice { get; set; }
        public string Nome { get; set; }
        public string PrimeiroNome => string.IsNullOrWhiteSpace(Nome) ? string.Empty : Nome.Split(' ')[0];
        public string Sobrenome => string.IsNullOrWhiteSpace(Nome) ? string.Empty : Nome.Replace(PrimeiroNome, string.Empty).Trim();
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int UsuarioTipo { get; set; } = (int)Dominio.UsuarioTipo.Aluno;
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string GoogleClassroomId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string google_classroom_id
        {
            get => GoogleClassroomId;
            set => GoogleClassroomId = value;
        }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string googleclassroomid
        {
            get => GoogleClassroomId;
            set => GoogleClassroomId = value;
        }

        public bool ExisteGoogle { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public bool existe_google
        {
            get => ExisteGoogle;
            set => ExisteGoogle = value;
        }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public bool existegoogle
        {
            get => ExisteGoogle;
            set => ExisteGoogle = value;
        }
    }
}

