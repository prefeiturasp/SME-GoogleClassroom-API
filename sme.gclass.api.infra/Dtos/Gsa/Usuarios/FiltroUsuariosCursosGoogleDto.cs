namespace SME.GoogleClassroom.Infra
{
    public class FiltroUsuariosCursosGoogleDto
    {
        public FiltroUsuariosCursosGoogleDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public FiltroUsuariosCursosGoogleDto()
        {
            TokenProximaPagina = null;
        }

        public string TokenProximaPagina { get; set; }
    }
}