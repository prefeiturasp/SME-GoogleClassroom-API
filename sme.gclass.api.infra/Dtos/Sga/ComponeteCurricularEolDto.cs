﻿using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ComponeteCurricularEolDto
    {
        public long ComponenteCodigo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ProfessorEolDto> Professores { get; set; }
    }
}