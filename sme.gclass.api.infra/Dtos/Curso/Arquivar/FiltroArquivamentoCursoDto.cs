namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoCursoDto
    {
        public int AnoLetivo { get; set; }

        public long? TurmaId { get; set; }

        public FiltroArquivamentoCursoDto(int anoLetivo, long? turmaId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }
    }
}
