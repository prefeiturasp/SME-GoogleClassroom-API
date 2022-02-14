namespace SME.GoogleClassroom.Infra
{
    public class FiltroFormacaoCidadeTurmasDto
    {
        public string CodigoDre { get; set; }
        public int? ComponenteCurricularId { get; set; }

        public FiltroFormacaoCidadeTurmasDto(string codigoDre = null, int? componenteCurricularId = null)
        {
            CodigoDre = codigoDre;
            ComponenteCurricularId = componenteCurricularId;
        }
    }
}
