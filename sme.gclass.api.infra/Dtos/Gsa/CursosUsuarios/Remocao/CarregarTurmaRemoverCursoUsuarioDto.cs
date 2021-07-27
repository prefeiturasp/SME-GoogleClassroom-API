namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto(long? turmaId, bool processarAlunos, bool processarProfessores)
        {
            TurmaId = turmaId;
            ProcessarAlunos = processarAlunos;
            ProcessarProfessores = processarProfessores;
        }

        public long? TurmaId { get; set; }
        public bool ProcessarAlunos { get; set; }
        public bool ProcessarProfessores { get; set; }
    }
 }