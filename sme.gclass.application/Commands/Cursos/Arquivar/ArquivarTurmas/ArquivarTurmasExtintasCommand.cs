using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasExtintasCommand : IRequest
    {
        public ArquivarTurmasExtintasCommand(long? turmaId = null)
        {
            TurmaId = turmaId;
        }

        public long? TurmaId { get; }
    }
}
