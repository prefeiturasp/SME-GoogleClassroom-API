namespace SME.GoogleClassroom.Dominio
{
    public class Paginacao
    {
        public Paginacao(int pagina, int registros)
        {
            Pagina = pagina;
            pagina = pagina < 1 ? 1 : pagina;
            registros = registros < 1 ? 0 : registros;

            QuantidadeRegistros = registros;
            QuantidadeRegistrosIgnorados = (pagina - 1) * registros;
        }

        public int Pagina { get; set; }
        public int QuantidadeRegistros { get; set; }
        public int QuantidadeRegistrosIgnorados { get; set; }
    }
}