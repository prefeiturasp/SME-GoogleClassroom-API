namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaMuralAvisosCursoDto : FiltroCargaGsaDto
    {
        public FiltroCargaMuralAvisosCursoDto(long? cursoId = null)
        {
            CursoId = cursoId;
        }
        public long? CursoId { get; set; }
    }
}
