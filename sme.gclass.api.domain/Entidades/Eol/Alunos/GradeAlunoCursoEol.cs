using System;

namespace SME.GoogleClassroom.Dominio
{
    public class GradeAlunoCursoEol
    {
        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public DateTime DataInicioGrade { get; set; }
        public string CdUe { get; set; }

        protected GradeAlunoCursoEol()
        {
        }

        public GradeAlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId, DateTime dataInicioGrade, string cdUe)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            DataInicioGrade = dataInicioGrade;
            CdUe = cdUe;
        }
    }
}