using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarProfessoresInativosDto
    {
        public CarregarProfessoresInativosDto(DateTime dataReferencia, long? professorId = null)
        {
            DataReferencia = dataReferencia;
            ProfessorId = professorId;
        }

        public DateTime DataReferencia { get; set; }
        public long? ProfessorId { get; set; }
    }
}
