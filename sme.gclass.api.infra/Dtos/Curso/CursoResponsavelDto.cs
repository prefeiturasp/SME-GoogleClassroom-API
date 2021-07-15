using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class CursoResponsavelDto
    {
        public CursoResponsavelDto()
        {
            Responsaveis = new List<UsuarioGoogleClassroomDto>();
        }

        public long CursoId { get; set; }
        public List<UsuarioGoogleClassroomDto> Responsaveis { get; set; }
    }
}
