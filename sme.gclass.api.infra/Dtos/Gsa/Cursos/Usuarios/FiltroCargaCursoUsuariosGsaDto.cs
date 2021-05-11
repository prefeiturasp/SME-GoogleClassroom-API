namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaCursoUsuariosGsaDto
    {
        public FiltroCargaCursoUsuariosGsaDto(string tokenProximaPagina, CursoGsaDto curso, short usuarioCursoTipo)
        {
            TokenProximaPagina = tokenProximaPagina;
            Curso = curso;
            UsuarioCursoTipo = usuarioCursoTipo;
        }

        public FiltroCargaCursoUsuariosGsaDto(CursoGsaDto curso, short usuarioCursoTipo)
        {
            TokenProximaPagina = null;
            Curso = curso;
            UsuarioCursoTipo = usuarioCursoTipo;
        }

        public FiltroCargaCursoUsuariosGsaDto()
        {
        }

        public string TokenProximaPagina { get; set; }
        public CursoGsaDto Curso { get; set; }
        public short UsuarioCursoTipo { get; set; }
    }
}