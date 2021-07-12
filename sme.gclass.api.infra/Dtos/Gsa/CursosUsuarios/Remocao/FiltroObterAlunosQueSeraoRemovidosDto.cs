using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosQueSeraoRemovidosDto : FiltroPaginacaoBaseDto
    {
        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
