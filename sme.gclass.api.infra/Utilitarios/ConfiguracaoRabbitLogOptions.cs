namespace SME.GoogleClassroom.Infra
{
    public class ConfiguracaoRabbitLogOptions
    {
        public const string Secao = "ConfiguracaoRabbitLog";
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
    }
}
