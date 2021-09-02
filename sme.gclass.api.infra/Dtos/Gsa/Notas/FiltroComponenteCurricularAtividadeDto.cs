namespace SME.GoogleClassroom.Infra
{
    public class FiltroComponenteCurricularAtividadeDto : FiltroPaginacaoBaseDto
    {
        public FiltroComponenteCurricularAtividadeDto(long componenteCurricularId, bool lancaNota, int pagina, int quantidadeRegistros)
        {
            ComponenteCurricularId = componenteCurricularId;
            LancaNota = lancaNota;
            PaginaNumero = pagina;
            RegistrosQuantidade = quantidadeRegistros;
        }

        public long ComponenteCurricularId { get; set; }
        public bool LancaNota { get; set; }
    }
}
