using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class AlunosInativosPorTurmaDto
    {
        public AlunosInativosPorTurmaDto(IEnumerable<long> alunosCodigos, long turmaId)
        {
            AlunosCodigos = alunosCodigos;
            TurmaId = turmaId;
        }

        public IEnumerable<long> AlunosCodigos { get; set; }
        public long TurmaId { get; set; }
    }
}
