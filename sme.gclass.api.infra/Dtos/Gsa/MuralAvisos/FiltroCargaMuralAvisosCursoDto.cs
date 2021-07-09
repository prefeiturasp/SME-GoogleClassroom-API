namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaMuralAvisosCursoDto
    {
        public FiltroCargaMuralAvisosCursoDto(CursoResponsavelDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
        public CursoResponsavelDto Curso { get; set; }
    }
}
