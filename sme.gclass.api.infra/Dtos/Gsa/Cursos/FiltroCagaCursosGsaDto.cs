namespace SME.GoogleClassroom.Infra
{
    public class FiltroCagaCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public bool ExecutarCargaDeUsuariosGsa { get; set; }

        public FiltroCagaCursosGsaDto(string tokenProximaPagina, bool executarCargaDeUsuariosGsa)
        {
            TokenProximaPagina = tokenProximaPagina;
            ExecutarCargaDeUsuariosGsa = executarCargaDeUsuariosGsa;
        }

        public FiltroCagaCursosGsaDto()
        {
            TokenProximaPagina = null;
            ExecutarCargaDeUsuariosGsa = true;
        }
    }
}