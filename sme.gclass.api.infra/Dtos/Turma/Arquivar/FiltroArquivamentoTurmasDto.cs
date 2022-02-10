using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroArquivamentoTurmasDto
    {
        public FiltroArquivamentoTurmasDto()
        {
        }

        public FiltroArquivamentoTurmasDto(long? turmaId = null, DateTime? dataReferencia = null)
        {
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
        }

        public long? TurmaId { get; set; }
        public DateTime? DataReferencia { get; set; }
    }
}
