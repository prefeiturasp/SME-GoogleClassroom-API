namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoCursoPorAnoSemestreDto
    {
        public int Ano { get; set; }
        public int? Semestre { get; set; }

        public FiltroArquivamentoCursoPorAnoSemestreDto(int ano = 0, int? semestre = 0)
        {
            Ano = ano;
            Semestre = semestre;
        }
    }
}
