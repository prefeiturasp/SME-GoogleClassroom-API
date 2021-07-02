namespace SME.GoogleClassroom.Dominio
{
    public class BaseErro
    {
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public ErroTipo Tipo { get; set; }
        public string Mensagem { get; set; }
    }
}
