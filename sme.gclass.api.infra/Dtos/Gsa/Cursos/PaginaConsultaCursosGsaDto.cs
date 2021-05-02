using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public IEnumerable<CursoGsaDto> Cursos { get; set; }
    }
}