namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO
    {
        public long CodigoTurma { get; set; }
        public string Rf { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Tutor { get; set; }
    }
}