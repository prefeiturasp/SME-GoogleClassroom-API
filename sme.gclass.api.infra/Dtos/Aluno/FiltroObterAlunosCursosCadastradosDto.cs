namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosCursosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? CodigoAluno { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
    }
}
