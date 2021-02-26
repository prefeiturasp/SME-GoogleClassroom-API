namespace SME.GoogleClassroom.Infra
{
    public class TurmaParaIncluirDto
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string Email { get; set; }
        public string ProfessorRF { get; set; }
    }
}
