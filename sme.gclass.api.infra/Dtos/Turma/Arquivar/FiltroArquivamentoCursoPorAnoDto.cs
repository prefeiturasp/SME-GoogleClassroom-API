namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoCursoPorAnoDto
    {
        public int Ano { get; set; }
        public long? TurmaId { get; set; }

        public FiltroArquivamentoCursoPorAnoDto(int ano = 0, long? turmaId = null)
        {
            Ano = ano;
            TurmaId = turmaId;
        }
    }
}
