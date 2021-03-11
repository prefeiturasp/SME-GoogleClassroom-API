namespace SME.GoogleClassroom.Dominio
{
    public class AlunoCursoEol
    {
        public AlunoCursoEol()
        {

        }
        public AlunoCursoEol(long alunoCodigo, long turmaId, long componenteCurricularId)
        {
            AlunoCodigo = alunoCodigo;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public long AlunoCodigo { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
}
