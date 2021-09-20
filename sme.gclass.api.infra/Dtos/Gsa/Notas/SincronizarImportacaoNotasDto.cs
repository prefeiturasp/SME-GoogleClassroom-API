namespace SME.GoogleClassroom.Infra
{
    public class SincronizarImportacaoNotasDto
    {
        public SincronizarImportacaoNotasDto(DadosAvaliacaoDto dadosAvaliacao, NotaGsaDto nota)
        {
            DadosAvaliacao = dadosAvaliacao;
            Nota = nota;
        }

        public DadosAvaliacaoDto DadosAvaliacao { get; set; }
        public NotaGsaDto Nota { get; set; }
    }
}
