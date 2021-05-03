namespace SME.GoogleClassroom.Infra
{
    public class ConsumoDeFilasOptions
    {
        public ushort LimiteDeMensagensPorExecucao { get; set; }
        public bool ConsumirFilasSync { get; set; }
        public bool ConsumirFilasDeInclusao { get; set; }
        public bool ConsumirFilasDeCargaGsa { get; set; }
        public bool ConsumirFilasDeProcessamentoGsa { get; set; }
    }
}