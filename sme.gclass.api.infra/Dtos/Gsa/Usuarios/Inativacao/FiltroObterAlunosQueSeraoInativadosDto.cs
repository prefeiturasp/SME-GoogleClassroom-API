using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosQueSeraoInativadosDto : FiltroPaginacaoBaseDto
    {
        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
