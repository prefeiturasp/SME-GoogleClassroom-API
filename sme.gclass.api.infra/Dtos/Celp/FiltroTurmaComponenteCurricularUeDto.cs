namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaComponenteCurricularUeDto
    {
        public string ComponenteCurricularNome { get; set; }
        public string ComponenteCurricularCodigo { get; set; }
        public string TurmaCodigo { get; set; }
        public string Secao { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }
        public int TipoId { get; set; }
        public int TipoEscola { get; set; }
    }
}