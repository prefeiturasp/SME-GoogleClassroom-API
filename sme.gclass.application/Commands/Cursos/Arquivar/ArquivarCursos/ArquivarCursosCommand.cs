using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursosCommand: IRequest
    {
        public ArquivarCursosCommand(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; set; }
    }
}
