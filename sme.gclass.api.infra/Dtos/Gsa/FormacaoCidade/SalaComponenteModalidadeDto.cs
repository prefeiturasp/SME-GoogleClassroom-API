namespace SME.GoogleClassroom.Infra
{
    public class SalaComponenteModalidadeDto
    {
        public string SalaVirtual { get; set; }
        public string ComponentesCurricularIds { get; set; }
        public string ModalidadesIds { get; set; }
        public string Modalidade { get; set; }
        public string CodigoDre { get; set; }
        public int[] TipoEscola { get; set; }
        public int AnoLetivo { get; set; }
        public string AnoTurma { get; set; }
        public int TipoConsulta { get; set; }
        public int TipoSala { get; set; }
        public bool IncluirAlunoCurso { get; set; }

        public SalaComponenteModalidadeDto(string salaVirtual, string componentesCurricularIds, string modalidadesIds, string modalidade, int[] tipoEscola, int tipoConsulta, int tipoSala, string anoTurma = null, bool incluirAlunoCurso = true)
        {
            SalaVirtual = salaVirtual;
            ComponentesCurricularIds = componentesCurricularIds;
            ModalidadesIds = modalidadesIds;
            Modalidade = modalidade;
            TipoEscola = tipoEscola;
            AnoTurma = anoTurma;
            TipoConsulta = tipoConsulta;
            TipoSala = tipoSala;
            IncluirAlunoCurso = incluirAlunoCurso;
        }

        public SalaComponenteModalidadeDto()
        {
        }
    }
}