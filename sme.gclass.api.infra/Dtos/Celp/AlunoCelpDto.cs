using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoCelpDto
    {
        public long CodigoAluno { get; set; }
        public long TurmaCodigo { get; set; }
        public long ComponenteCodigo { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}