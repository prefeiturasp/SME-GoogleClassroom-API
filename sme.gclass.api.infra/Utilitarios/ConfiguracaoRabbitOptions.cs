namespace SME.GoogleClassroom.Infra
{
    public class ConfiguracaoRabbitOptions
    {
        public const string Secao = "ConfiguracaoRabbit";
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Virtualhost { get; set; }
        public ushort LimiteDeMensagensPorExecucao { get; set; }
    }
}
