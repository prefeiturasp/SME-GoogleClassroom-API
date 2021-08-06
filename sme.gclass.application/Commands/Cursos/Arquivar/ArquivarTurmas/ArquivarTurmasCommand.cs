using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasCommand: IRequest
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }

        public ArquivarTurmasCommand(int anoLetivo, long? turmaId = null)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }
    }
}
