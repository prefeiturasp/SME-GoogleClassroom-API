namespace SME.GoogleClassroom.Dominio
{
    public class AlunoCursoEol
    {
        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string UeCodigo { get; set; }

        public AlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        protected AlunoCursoEol()
        {
        }
    }
}