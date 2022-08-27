namespace SME.GoogleClassroom.Infra
{
    public class FiltroSincronizacaoCelpDto
    {
        public int AnoLetivo { get; set; }
        
        public FiltroSincronizacaoCelpDto(){}

        public FiltroSincronizacaoCelpDto(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        } 
    }
}