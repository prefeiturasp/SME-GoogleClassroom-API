namespace SME.GoogleClassroom.Infra
{
    public class TurmaCCErroDto
    {
        public TurmaCCErroDto(string nome, string secao, long componenteCurricularId, long turmaId, string professorRF, string email, string mensagem)
        {
            Nome = nome;
            Secao = secao;
            ComponenteCurricularId = componenteCurricularId;
            TurmaId = turmaId;
            ProfessorRF = professorRF;
            Email = email;
            Mensagem = mensagem;
        }

        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string ProfessorRF { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }
}
