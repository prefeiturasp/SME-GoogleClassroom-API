namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoTurmasDto
    {
        public FiltroArquivamentoTurmasDto()
        {
        }

        public FiltroArquivamentoTurmasDto(long? turmaId = null)
        {
            TurmaId = turmaId;
        }

        public long? TurmaId { get; set; }
    }
}
