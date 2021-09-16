using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasCommand: IRequest
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }

        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ArquivarTurmasCommand(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, long? turmaId = null)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }
}
