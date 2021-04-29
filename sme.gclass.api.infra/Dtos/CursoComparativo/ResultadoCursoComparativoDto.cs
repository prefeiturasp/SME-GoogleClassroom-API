using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class ResultadoCursoComparativoDto
    {
        public string  NextToken { get; set; }
        public IEnumerable<CursoComparativoDto> Cursos { get; set; }
    }
}
