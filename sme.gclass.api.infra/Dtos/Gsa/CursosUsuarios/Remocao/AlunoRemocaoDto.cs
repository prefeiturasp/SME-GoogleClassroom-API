using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoRemocaoDto
    {
        public long Codigo { get; set; }
        public string NomePessoa { get; set; }
        public string NomeSocial { get; set; }
        public string Nome => !string.IsNullOrWhiteSpace(NomeSocial) ? NomeSocial : NomePessoa;
        public DateTime DataNascimento { get; set; }
        public long TurmaId { get; set; }
        public int SituacaoMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
    }
}
