using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginaConsultaUsuariosGsaDto
    {
        public string TokenProximaPagina { get; set; }
        public IEnumerable<UsuarioGsaDto> Usuarios { get; set; }

        public PaginaConsultaUsuariosGsaDto()
        {
            Usuarios = new List<UsuarioGsaDto>();
        }
    }
}