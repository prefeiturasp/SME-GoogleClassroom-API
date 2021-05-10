using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public List<CursoGsaDto> Cursos { get; set; }
        public PaginaConsultaCursosGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
            Cursos = new List<CursoGsaDto>();
        }
    }
}