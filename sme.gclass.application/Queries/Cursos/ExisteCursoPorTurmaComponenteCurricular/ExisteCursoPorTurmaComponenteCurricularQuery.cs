using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoPorTurmaComponenteCurricularQuery : IRequest<bool>
    {
        public ExisteCursoPorTurmaComponenteCurricularQuery(long turmaId, long componenteCurricularId)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
}
