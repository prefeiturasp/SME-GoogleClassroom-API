using StackExchange.Redis;

namespace SME.GoogleClassroom.Infra.EnvironmentVariables
{
    public class RedisOptions
    {
        public const string Secao = "RedisOptions";
        public string Endpoint { get; set; }
        public Proxy Proxy { get; set; } = Proxy.None;
        public int SyncTimeout { get; set; } = 5000;
        public string InstanceName { get; set; } = "googleclassroom:";
        public int MinutosExpiracaoPadrao { get; set; } = 720;
    }
}