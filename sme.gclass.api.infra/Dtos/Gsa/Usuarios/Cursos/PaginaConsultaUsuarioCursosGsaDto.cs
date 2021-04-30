using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaUsuarioCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public IEnumerable<UsuarioCursoGsaDto> CursosDoUsuario { get; set; }

        public PaginaConsultaUsuarioCursosGsaDto()
        {
            CursosDoUsuario = new List<UsuarioCursoGsaDto>();
        }
    }
}