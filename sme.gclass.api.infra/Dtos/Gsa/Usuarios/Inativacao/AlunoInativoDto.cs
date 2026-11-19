using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoInativoDto
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TurmaId { get; set; }
        public int SituacaoMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
    }
}
