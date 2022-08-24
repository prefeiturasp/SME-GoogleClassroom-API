namespace SME.GoogleClassroom.Dominio
{
    public class CursoEol
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }
        public TurmaTipo TurmaTipo { get; set; }
        public TipoEscola TipoEscola { get; set; }

        public CursoEol(string nome, string secao, long turmaId, long componenteCurricularId, string ueCodigo, string email)
        {
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Email = email;
            UeCodigo = ueCodigo;            
        }

        public CursoEol(string nome, string secao, long turmaId, long componenteCurricularId, string ueCodigo, string email, TurmaTipo turmaTipo)
        {
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Email = email;
            UeCodigo = ueCodigo;
            TurmaTipo = turmaTipo;
        }

        protected CursoEol()
        {
        }
    }
}