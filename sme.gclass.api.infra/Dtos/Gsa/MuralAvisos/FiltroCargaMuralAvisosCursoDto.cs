namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaMuralAvisosCursoDto : FiltroCargaGsaDto
    {
        public FiltroCargaMuralAvisosCursoDto(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
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
