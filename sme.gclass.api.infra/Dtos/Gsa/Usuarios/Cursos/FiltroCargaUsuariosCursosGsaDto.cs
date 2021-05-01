namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaUsuariosCursosGsaDto
    {
        public FiltroCargaUsuariosCursosGsaDto(string tokenProximaPagina, UsuarioGsaDto usuario)
        {
            TokenProximaPagina = tokenProximaPagina;
            Usuario = usuario;
        }

        public FiltroCargaUsuariosCursosGsaDto(UsuarioGsaDto usuario)
        {
            TokenProximaPagina = null;
            Usuario = usuario;
        }

        public FiltroCargaUsuariosCursosGsaDto()
        {
        }

        public string TokenProximaPagina { get; set; }
        public UsuarioGsaDto Usuario { get; set; }
    }
}