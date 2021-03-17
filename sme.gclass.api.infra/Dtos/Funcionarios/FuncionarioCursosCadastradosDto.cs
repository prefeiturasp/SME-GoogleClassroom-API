using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FuncionarioCursosCadastradosDto
    {
        public FuncionarioCursosCadastradosDto()
        {
            Cursos = new List<CursoDto>();
        }

        public long Rf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public ICollection<CursoDto> Cursos { get; set; }
    }
}
