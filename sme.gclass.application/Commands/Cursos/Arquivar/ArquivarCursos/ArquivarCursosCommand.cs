using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursosCommand: IRequest
    {
        public ArquivarCursosCommand(int anoLetivo, int? semestre = 0)
        {
            AnoLetivo = anoLetivo;
            Semestre = semestre;
        }

        public int AnoLetivo { get; set; }
        public int? Semestre { get; set; }
    }
}
