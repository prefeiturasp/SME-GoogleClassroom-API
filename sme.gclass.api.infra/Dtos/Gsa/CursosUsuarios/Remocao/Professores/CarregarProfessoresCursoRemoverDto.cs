using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarProfessoresCursoRemoverDto
    {
        public CarregarProfessoresCursoRemoverDto(long? turmaId = null, bool processarAlunos = false, bool processarProfessores = false)
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
