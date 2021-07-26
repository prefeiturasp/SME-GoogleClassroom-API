namespace SME.GoogleClassroom.Dominio
{
    public class ParametrosSistema
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ETipoParametroSistema Tipo { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int? Ano { get; set; }
        public bool Ativo { get; set; }
    }
}