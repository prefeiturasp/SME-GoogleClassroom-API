using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaNotasGsaDto
    {
        public PaginaConsultaNotasGsaDto(DadosAvaliacaoNotasGsaDto dadosAtividade, string tokenProximaPagina = "")
        {
            TokenProximaPagina = tokenProximaPagina;
            DadosAtividade = dadosAtividade;
            Notas = new List<NotaGsaDto>();
        }
        public DadosAvaliacaoNotasGsaDto DadosAtividade { get; set; }
        public string TokenProximaPagina { get; set; }
        public ICollection<NotaGsaDto> Notas { get; set; }
    }
}
