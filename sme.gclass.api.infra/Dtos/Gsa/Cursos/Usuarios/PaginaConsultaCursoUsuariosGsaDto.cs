using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaCursoUsuariosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public List<UsuarioCursoGsaDto> CursosDoUsuario { get; set; }

        public PaginaConsultaCursoUsuariosGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
            CursosDoUsuario = new List<UsuarioCursoGsaDto>();
        }
    }
}