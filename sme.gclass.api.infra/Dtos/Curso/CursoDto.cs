namespace SME.GoogleClassroom.Infra
{
    public class CursoDto
    {
        public long CursoId { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
}
