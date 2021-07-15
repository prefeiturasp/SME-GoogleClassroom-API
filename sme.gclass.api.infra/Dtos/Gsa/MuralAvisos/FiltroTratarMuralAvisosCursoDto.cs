namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarMuralAvisosCursoDto
    {
        public FiltroTratarMuralAvisosCursoDto(CursoResponsavelDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
        public CursoResponsavelDto Curso { get; set; }
    }
}
