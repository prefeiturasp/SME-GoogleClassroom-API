using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class AlunosCursoUsuarioRemovidoTurmaDto
    {
        public AlunosCursoUsuarioRemovidoTurmaDto(IEnumerable<long> alunosCodigos, long turmaId)
        {
            AlunosCodigos = alunosCodigos;
            TurmaId = turmaId;
        }

        public IEnumerable<long> AlunosCodigos { get; set; }
        public long TurmaId { get; set; }
    }
}
