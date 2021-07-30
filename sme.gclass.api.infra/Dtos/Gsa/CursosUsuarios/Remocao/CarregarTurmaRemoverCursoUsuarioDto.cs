namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto(long? turmaId, bool processarAlunos, bool processarProfessores, bool processarFuncionario)
        {
            TurmaId = turmaId;
            ProcessarAlunos = processarAlunos;
            ProcessarProfessores = processarProfessores;
            ProcessarFuncionario = processarFuncionario;

        }

        public long? TurmaId { get; set; }
        public bool ProcessarAlunos { get; set; }
        public bool ProcessarProfessores { get; set; }
        public bool ProcessarFuncionario { get; set; }
        
    }
 }