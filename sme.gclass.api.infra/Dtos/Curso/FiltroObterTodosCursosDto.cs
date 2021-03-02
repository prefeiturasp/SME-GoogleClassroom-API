namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterTodosCursosDto : FiltroPaginacaoBaseDto
    {
        public long? TurmaCodigo { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? CursoId { get; set; }
        public string EmailCriador { get; set; }
    }
}
