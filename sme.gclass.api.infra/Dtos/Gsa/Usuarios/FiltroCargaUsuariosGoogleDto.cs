namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaUsuariosGoogleDto
    {
        public FiltroCargaUsuariosGoogleDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public FiltroCargaUsuariosGoogleDto()
        {
            TokenProximaPagina = null;
        }

        public string TokenProximaPagina { get; set; }
    }
}