namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaAtividadesCursoDto
    {
        public FiltroCargaAtividadesCursoDto(long? cursoId = null)
        {
            CursoId = cursoId;
        }

        public long? CursoId { get; set; }
    }
}
