namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoCursoDto
    {
        public FiltroArquivamentoCursoDto(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; set; }
    }
}
