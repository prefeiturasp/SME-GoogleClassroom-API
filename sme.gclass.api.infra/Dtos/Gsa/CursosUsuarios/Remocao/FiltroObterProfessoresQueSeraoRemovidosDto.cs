using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterProfessoresQueSeraoRemovidosDto : FiltroPaginacaoBaseDto
    {
        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
