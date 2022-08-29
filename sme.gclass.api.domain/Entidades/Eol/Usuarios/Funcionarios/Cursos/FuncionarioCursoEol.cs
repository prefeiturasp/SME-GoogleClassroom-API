namespace SME.GoogleClassroom.Dominio
{ 
    public class FuncionarioCursoEol
    {
        public long Rf { get; set; }        
        public long Indice { get; set; }        
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }

        public FuncionarioCursoEol(long rf, long turmaId, long componenteCurricularId)
        {
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
        
        public FuncionarioCursoEol(string email, long indice, long rf, long turmaId, long componenteCurricularId)
        {
            Email = email;
            Indice = indice;
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        protected FuncionarioCursoEol()
        {
        }        
    }
}