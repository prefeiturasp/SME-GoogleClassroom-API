namespace SME.GoogleClassroom.Infra
{
    public class FiltroFormacaoCidadeTurmaCursoDto
    {
        public string SalaVirtual { get; set; }
        public string CodigoDre { get; set; }
        public string ComponentesCurricularesIds { get; set; }
        public string ModalidadesIds { get; set; }
        public int AnoLetivo { get; set; }
        public int[] TipoEscola { get; set; }
        public int TipoConsulta { get; set; }
        public string AnoTurma { get; set; }
        public bool IncluirAlunoCurso { get; set; }
        public string MensagemErro { get; set; }

        public FiltroFormacaoCidadeTurmaCursoDto(string salaVirtual, string codigoDre, int anoLetivo, string componentesCurricularesIds, string modalidadesIds, int[] tipoEscola, int tipoConsultaProfessor, string anoTurma, bool incluirAlunoCurso)
        {
            SalaVirtual = salaVirtual;
            CodigoDre = codigoDre;
            ComponentesCurricularesIds = componentesCurricularesIds;
            ModalidadesIds = modalidadesIds;
            AnoLetivo = anoLetivo;
            TipoEscola = tipoEscola;
            TipoConsulta = tipoConsultaProfessor;
            AnoTurma = anoTurma;
            IncluirAlunoCurso = incluirAlunoCurso;
        }
    }
}
