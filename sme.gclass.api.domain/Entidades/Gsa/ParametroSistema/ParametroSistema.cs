namespace SME.GoogleClassroom.Dominio
{
    public class ParametrosSistema
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public TipoParametroSistema Tipo { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }

        public ParametrosSistema()
        {
        }

        public ParametrosSistema(long id, string nome, TipoParametroSistema tipo, string descricao, string valor, int ano, bool ativo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
            Ano = ano;
            Ativo = ativo;
        }
    }
}