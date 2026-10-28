using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoCursosCadastradosDto
    {
        public AlunoCursosCadastradosDto()
        {
            Cursos = new List<CursoCadastradoDto>();
        }

        public long CodigoAluno { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<CursoCadastradoDto> Cursos { get; set; }
    }
}
