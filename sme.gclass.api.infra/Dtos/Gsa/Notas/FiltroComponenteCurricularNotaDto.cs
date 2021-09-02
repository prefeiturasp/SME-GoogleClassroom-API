namespace SME.GoogleClassroom.Infra
{
    public class FiltroComponenteCurricularNotaDto : FiltroPaginacaoBaseDto
    {
        public FiltroComponenteCurricularNotaDto(long id, bool lancaNota, int pagina, int totalPagina)
        {
            Id = id;
            LancaNota = lancaNota;
            PaginaNumero = pagina;
            RegistrosQuantidade = totalPagina;
        }

        public long Id { get; set; }
        public bool LancaNota { get; set; }
    }
}
