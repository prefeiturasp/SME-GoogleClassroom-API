using MediatR;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasExtintasCommand : IRequest
    {
        public ArquivarTurmasExtintasCommand(ParametrosCargaInicialDto parametrosCargaInicialDto, long? turmaId = null, DateTime? dataReferencia = null)
        {
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;

        }

        public long? TurmaId { get; }
        public DateTime? DataReferencia { get; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto{ get; set; }
    }
}
