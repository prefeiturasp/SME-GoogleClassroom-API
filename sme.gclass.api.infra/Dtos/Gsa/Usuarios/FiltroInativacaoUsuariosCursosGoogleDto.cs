namespace SME.GoogleClassroom.Infra
{
    public class FiltroInativacaoUsuariosCursosGoogleDto
    {
        public FiltroInativacaoUsuariosCursosGoogleDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public FiltroInativacaoUsuariosCursosGoogleDto()
        {
            TokenProximaPagina = null;
        }

        public string TokenProximaPagina { get; set; }
    }
}

