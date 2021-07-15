using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class CursoResponsavelDto
    {
        public CursoResponsavelDto(long cursoId, IEnumerable<string> responsaveis)
        {
            CursoId = cursoId;
            Responsaveis = responsaveis;
        }

        public long CursoId { get; set; }
        public IEnumerable<string> Responsaveis { get; set; }
    }
}
