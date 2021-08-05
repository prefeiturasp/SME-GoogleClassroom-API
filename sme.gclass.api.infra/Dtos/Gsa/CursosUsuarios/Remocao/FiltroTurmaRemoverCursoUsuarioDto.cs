using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaRemoverCursoUsuarioDto
    {
        public FiltroTurmaRemoverCursoUsuarioDto(VigenciaDto datasAluno, VigenciaDto datasProfessor, VigenciaDto datasFuncionario, long turmaId, bool processarAlunos, bool processarProfessores,  bool processarFuncionario)
        {
            DatasAluno = datasAluno;
            DatasProfessor = datasProfessor;
            DatasFuncionario = datasFuncionario;
            TurmaId = turmaId;
            ProcessarAlunos = processarAlunos;
            ProcessarProfessores = processarProfessores;
            ProcessarFuncionario = processarFuncionario;
        }

        public VigenciaDto DatasAluno { get; set; }
        public VigenciaDto DatasProfessor { get; set; }
        public VigenciaDto DatasFuncionario { get; set; }
        public long TurmaId { get; set; }
        public bool ProcessarAlunos { get; set; }
        public bool ProcessarProfessores { get; set; }
        public bool ProcessarFuncionario { get; set; }
    }
}
