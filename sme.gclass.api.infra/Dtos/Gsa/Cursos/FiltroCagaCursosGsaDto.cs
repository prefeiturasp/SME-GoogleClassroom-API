namespace SME.GoogleClassroom.Infra
{
    public class FiltroCagaCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }

        public FiltroCagaCursosGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public FiltroCagaCursosGsaDto()
        {
            TokenProximaPagina = null;
        }
    }
}