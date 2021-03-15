namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterFuncionariosCursosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? Rf { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
    }
}
