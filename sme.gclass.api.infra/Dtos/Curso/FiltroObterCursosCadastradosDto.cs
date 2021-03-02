namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterCursosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? CursoId { get; set; }
        public string EmailCriador { get; set; }
    }
}
