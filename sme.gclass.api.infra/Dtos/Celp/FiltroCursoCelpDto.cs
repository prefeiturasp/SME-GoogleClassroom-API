using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCursoCelpDto
    {
        public string ComponenteCurricularNome { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string Secao { get; set; }
        public string UeCodigo { get; set; }
        public string EmailProfessor { get; set; }
        public int TipoId { get; set; }
        public int TipoEscola { get; set; }
        public string EmailCoordenador { get; set; }
        public long IndiceCoordenador { get; set; }
        public long? RfCoordenador { get; set; }
        public int AnoLetivo { get; set; }
    }
}