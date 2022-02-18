using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroFormacaoCidadeTurmaComponenteDto
    {
        public string SalaVirtual { get; set; }
        public string CodigoDre { get; set; }
        public int? ComponenteCurricularId { get; set; }
        public int AnoLetivo { get; set; }
        public IEnumerable<SalaComponenteModalidadeDto> SalasVirtuais { get; set; }

        public FiltroFormacaoCidadeTurmaComponenteDto(string salaVirtual, IEnumerable<SalaComponenteModalidadeDto> salasVirtuais, string codigoDre, int anoLetivo, int? componenteCurricularId = null)
        {
            SalaVirtual = salaVirtual;
            CodigoDre = codigoDre;
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
            SalasVirtuais = salasVirtuais;
        }
    }
}
