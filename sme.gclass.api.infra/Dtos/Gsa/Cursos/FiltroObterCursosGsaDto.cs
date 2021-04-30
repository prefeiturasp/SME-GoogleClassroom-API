namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterCursosGsaDto : FiltroPaginacaoBaseDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Secao { get; set; }
    }
}
