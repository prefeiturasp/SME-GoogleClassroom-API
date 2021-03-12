using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AtribuicaoAlunoCursoEol
    {
        public AtribuicaoAlunoCursoEol()
        {

        }
        public AtribuicaoAlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId, DateTime dataAtribuicao, string cdUe)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            DataAtribuicao = dataAtribuicao;
            CdUe = cdUe;
        }

        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public string CdUe { get; set; }
    }
}
