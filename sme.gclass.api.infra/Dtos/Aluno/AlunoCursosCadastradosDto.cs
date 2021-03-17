using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoCursosCadastradosDto
    {
        public AlunoCursosCadastradosDto()
        {
            Cursos = new List<CursoDto>();
        }

        public long CodigoAluno { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<CursoDto> Cursos { get; set; }
    }
}
