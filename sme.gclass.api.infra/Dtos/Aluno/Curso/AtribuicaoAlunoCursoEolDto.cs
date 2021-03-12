using System;

namespace SME.GoogleClassroom.Infra
{
    public class AtribuicaoAlunoCursoEolDto
    {
        public long CodigoAluno { get; set; }
        public string Nome { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public string CdUe { get; set; }
    }
}
