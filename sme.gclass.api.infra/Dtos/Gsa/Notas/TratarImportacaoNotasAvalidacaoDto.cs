namespace SME.GoogleClassroom.Infra
{
    public class TratarImportacaoNotasAvalidacaoDto
    {
        public TratarImportacaoNotasAvalidacaoDto(DadosAvaliacaoDto dadosAvaliacao, string tokenProximaPagina = "")
        {
            DadosAvaliacao = dadosAvaliacao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public DadosAvaliacaoDto DadosAvaliacao { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
