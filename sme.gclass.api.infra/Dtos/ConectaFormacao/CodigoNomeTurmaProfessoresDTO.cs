using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class CodigoNomeTurmaProfessoresDTO
    {
        public long CodigoTurma { get; set; }
        public string NomeTurma { get; set; }
        public IEnumerable<ProfessorRfCpfNomeEmailTutorDTO> Professores { get; set; }
    }
}