using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaAtividadesGsaDto
    {
        public PaginaConsultaAtividadesGsaDto(string tokenProximaPagina = "")
        {
            TokenProximaPagina = tokenProximaPagina;
            Atividades = new List<AtividadeGsaDto>();
        }

        public string TokenProximaPagina { get; set; }
        public ICollection<AtividadeGsaDto> Atividades { get; set; }
    }
}
