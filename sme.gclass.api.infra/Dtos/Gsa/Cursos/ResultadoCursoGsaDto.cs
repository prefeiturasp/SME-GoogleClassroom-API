using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class ResultadoCursoGsaDto
    {
        public string  NextToken { get; set; }
        public IEnumerable<CursoGsaDto> Cursos { get; set; }
    }
}
