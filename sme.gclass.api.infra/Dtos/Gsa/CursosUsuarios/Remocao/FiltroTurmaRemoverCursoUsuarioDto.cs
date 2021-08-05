using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaRemoverCursoUsuarioDto
    {
        public FiltroTurmaRemoverCursoUsuarioDto(DateTime dataInicio, DateTime dataFim, long turmaId, bool processarAlunos, bool processarProfessores,  bool processarFuncionario)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            TurmaId = turmaId;
            ProcessarAlunos = processarAlunos;
            ProcessarProfessores = processarProfessores;
            ProcessarFuncionario = processarFuncionario;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public long TurmaId { get; set; }
        public bool ProcessarAlunos { get; set; }
        public bool ProcessarProfessores { get; set; }
        public bool ProcessarFuncionario { get; set; }
    }
}
