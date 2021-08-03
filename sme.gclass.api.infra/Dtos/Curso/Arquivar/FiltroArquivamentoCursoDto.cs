namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoCursoDto
    {
        public FiltroArquivamentoCursoDto(int anoLetivo, int? semestre = 0)
        {
            AnoLetivo = anoLetivo;
            Semestre = semestre;
        }

        public int AnoLetivo { get; set; }
        public int? Semestre { get; set; }
    }
}
