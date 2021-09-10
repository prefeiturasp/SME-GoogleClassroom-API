namespace SME.GoogleClassroom.Infra
{
    public class FiltroComponenteCurricularAtividadeDto : FiltroPaginacaoBaseDto
    {
        public FiltroComponenteCurricularAtividadeDto(long componenteCurricularId, bool lancaNota, int totalDiasImportacao, int pagina, int quantidadeRegistros)
        {
            ComponenteCurricularId = componenteCurricularId;
            LancaNota = lancaNota;
            TotalDiasImportacao = totalDiasImportacao;
            PaginaNumero = pagina;
            RegistrosQuantidade = quantidadeRegistros;
        }

        public long ComponenteCurricularId { get; set; }
        public bool LancaNota { get; set; }
        public int TotalDiasImportacao { get; set; }
    }
}
