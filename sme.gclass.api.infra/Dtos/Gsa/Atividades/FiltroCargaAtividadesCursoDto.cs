namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaAtividadesCursoDto
    {
        public FiltroCargaAtividadesCursoDto(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
        {
            CursoId = cursoId;
            Pagina = pagina;
            TotalPaginas = totalPaginas;
        }

        public long? CursoId { get; set; }
        public int? Pagina { get; set; }
        public int? TotalPaginas { get; set; }
    }
}
