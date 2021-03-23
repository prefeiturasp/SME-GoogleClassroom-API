namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorCursoEol
    {
        public long Rf { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }

        public ProfessorCursoEol(long rf, long turmaId, long componenteCurricularId)
        {
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        protected ProfessorCursoEol()
        {
        }
    }
}