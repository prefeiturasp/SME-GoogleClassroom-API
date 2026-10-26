
namespace SME.GoogleClassroom.Infra.Dtos.Curso
{
    public class AlunoCursoParaIncluirGoogleDto
    {
        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string UeCodigo { get; set; }
    }
}
