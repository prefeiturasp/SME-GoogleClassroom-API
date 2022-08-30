using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosMatriculadosCelpQuery : IRequest<IReadOnlyList<AlunoCelpDto>>
    {
        public ObterAlunosMatriculadosCelpQuery(long componenteCurricularId, int anoLetivo, long turmaId)
        {
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }

        public long ComponenteCurricularId { get; }
        public long TurmaId { get; }
        public int AnoLetivo { get; }
    }
}