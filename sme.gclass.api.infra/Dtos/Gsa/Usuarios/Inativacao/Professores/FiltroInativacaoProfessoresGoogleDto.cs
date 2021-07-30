namespace SME.GoogleClassroom.Infra
{
    public class FiltroInativacaoProfessoresGoogleDto
    {
        public FiltroInativacaoProfessoresGoogleDto(long? professorId = null)
        {
            ProfessorId = professorId;
        }

        public long? ProfessorId { get; set; }
    }
}
