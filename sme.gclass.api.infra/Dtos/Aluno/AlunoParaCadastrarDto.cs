using System;

namespace SME.GoogleClassroom.Infra
{
    /// <summary>
    /// Representa um aluno do EOL que será incluído no Google Classroom.
    /// </summary>
    public class AlunoParaCadastrarDto
    {
        public long Codigo { get; set; }
        public string NomePessoa { get; set; }
        public string NomeSocial { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TurmaId { get; set; }
        public int SituacaoMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
    }
}

