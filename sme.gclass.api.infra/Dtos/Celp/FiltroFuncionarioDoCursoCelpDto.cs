namespace SME.GoogleClassroom.Infra
{
    public class FiltroFuncionarioDoCursoCelpDto
    {
        public string EmailCoordenadorParametro { get; set; }
        public long Indice { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long? Rf { get; set; }
    }
}