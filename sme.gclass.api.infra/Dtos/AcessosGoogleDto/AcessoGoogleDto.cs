namespace SME.GoogleClassroom.Infra
{
    public class AcessoGoogleDto
    {
        private string _privateKey { get; set; }
        public string AplicacaoNome { get; set; }

        public string EmailContaServico { get; set; }

        public string EmailAdmin { get; set; }

        public string PrivateKey { get { return _privateKey.Replace("\\n", ""); } set { _privateKey = value; } }
    }
}
