namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaGsaDto
    {
        public FiltroCargaGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public FiltroCargaGsaDto()
        {
            TokenProximaPagina = null;
        }

        public string TokenProximaPagina { get; set; }
        public string MensagemErro { get; set; }
    }
}
