namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioCursoEol
    {
        public FuncionarioCursoEol()
        {
        }
        public FuncionarioCursoEol(long rf, long turmaId, long componenteCurricularId)
        {
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public long Rf { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
}
