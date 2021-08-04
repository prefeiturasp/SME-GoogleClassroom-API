using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursosCommand: IRequest
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }

        public ArquivarCursosCommand(int anoLetivo, long? turmaId = null)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }
    }
}
