namespace SME.GoogleClassroom.Infra
{
    public class FiltroFormacaoCidadeTurmaDto
    {
        public string CodigoDre { get; set; }
        public int? ComponenteCurricularId { get; set; }
        public int AnoLetivo { get; set; }
        public string MensagemErro { get; set; }

        public FiltroFormacaoCidadeTurmaDto(int anoLetivo, string codigoDre = null,  int? componenteCurricularId = null)
        {
            CodigoDre = codigoDre;
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
        }
    }
}
