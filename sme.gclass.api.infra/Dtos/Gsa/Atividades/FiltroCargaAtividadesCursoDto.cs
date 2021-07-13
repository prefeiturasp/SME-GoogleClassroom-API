namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaAtividadesCursoDto
    {
        public FiltroCargaAtividadesCursoDto(CursoDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoDto Curso { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
