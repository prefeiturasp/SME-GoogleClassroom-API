using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasExtintasCommand : IRequest
    {
        public ArquivarTurmasExtintasCommand(ParametrosCargaInicialDto parametrosCargaInicialDto, long? turmaId = null)
        {
            TurmaId = turmaId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public long? TurmaId { get; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto{ get; set; }
    }
}
