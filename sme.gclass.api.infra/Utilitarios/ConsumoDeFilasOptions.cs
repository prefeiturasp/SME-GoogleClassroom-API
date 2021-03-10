namespace SME.GoogleClassroom.Infra
{
    public class ConsumoDeFilasOptions
    {
        public const string Secao = "ConsumoDeFila";
        public bool ConsumirFilasSync { get; set; }
        public bool ConsumirFilasDeInclusao { get; set; }
    }
}