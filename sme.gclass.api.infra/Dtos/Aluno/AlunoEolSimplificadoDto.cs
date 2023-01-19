using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoEolSimplificadoDto
    {
        public AlunoEolSimplificadoDto()
        {}

        public long Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
