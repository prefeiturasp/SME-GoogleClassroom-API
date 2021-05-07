using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaUsuarioCursosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public List<UsuarioCursoGsaDto> CursosDoUsuario { get; set; }

        public PaginaConsultaUsuarioCursosGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
            CursosDoUsuario = new List<UsuarioCursoGsaDto>();
        }
    }
}