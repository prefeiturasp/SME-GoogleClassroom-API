namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmasArquivarDto : FiltroPaginacaoBaseDto
    {
        public int ano { get; set; }

        public int? semestre { get; set; }
    }
}
