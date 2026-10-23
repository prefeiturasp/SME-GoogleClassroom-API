using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class CursoAlunoParaCadastrarDto
    {
        public string CodigoAluno { get; set; }
        public string DataNascimento { get; set; }
        public List<CursoParaCadastrarDto> Cursos { get; set; }
    }
}

public class CursoParaCadastrarDto
{
    public long ComponenteCurricularId { get; set; }
    public long CursoId { get; set; }
    public long TurmaId { get; set; }
    public string UeCodigo { get; set; }
}

