using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaUsuariosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public List<UsuarioGsaDto> Usuarios { get; set; }

        public PaginaConsultaUsuariosGsaDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
            Usuarios = new List<UsuarioGsaDto>();
        }
    }
}