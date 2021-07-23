using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarProfessoresCursoRemoverDto
    {
        public CarregarProfessoresCursoRemoverDto()
        {

        }

        public CarregarProfessoresCursoRemoverDto(long? turmaId = null)
        {
            TurmaId = turmaId;
        }


        public long? TurmaId { get; set; }
    }
}
