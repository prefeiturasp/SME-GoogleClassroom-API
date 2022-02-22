namespace SME.GoogleClassroom.Dominio
{
    public class AlunoCursoEol
    {
        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long CursoId { get; set; }
        public string UeCodigo { get; set; }
        public string MensagemErro { get; set; }

        public AlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public AlunoCursoEol(long codigoAluno, long cursoId)
        {
            CodigoAluno = codigoAluno;
            CursoId = cursoId;
        }

        protected AlunoCursoEol()
        {
        }
    }
}