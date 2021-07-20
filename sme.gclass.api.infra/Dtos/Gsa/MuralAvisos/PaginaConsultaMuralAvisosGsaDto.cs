using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaMuralAvisosGsaDto
    {
        public PaginaConsultaMuralAvisosGsaDto(string tokenProximaPagina = "")
        {
            TokenProximaPagina = tokenProximaPagina;
            Avisos = new List<AvisoMuralGsaDto>();
        }

        public string TokenProximaPagina { get; set; }
        public ICollection<AvisoMuralGsaDto> Avisos { get; set; }
    }
}
