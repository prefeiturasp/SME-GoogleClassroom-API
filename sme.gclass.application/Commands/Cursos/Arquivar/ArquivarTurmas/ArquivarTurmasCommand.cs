using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasCommand : IRequest
    {
        public ArquivarTurmasCommand(long? turmaId = null)
        {
            TurmaId = turmaId;
        }

        public long? TurmaId { get; }
    }
}
