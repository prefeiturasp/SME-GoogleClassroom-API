namespace SME.GoogleClassroom.Infra
{
    public class SalaComponenteModalidadeDto
    {
        public string SalaVirtual { get; set; }
        public string ComponentesCurricularIds { get; set; }
        public string ModalidadesIds { get; set; }
        public string Modalidade { get; set; }
        public string CodigoDre { get; set; }
        public int TipoEscola { get; set; }
        public int AnoLetivo { get; set; }
        public string AnoTurma { get; set; }
        public int TipoConsultaProfessor { get; set; }

        public SalaComponenteModalidadeDto(string salaVirtual, string componentesCurricularIds, string modalidadesIds, string modalidade, int tipoEscola, int tipoConsulta, string anoTurma = null)
        {
            SalaVirtual = salaVirtual;
            ComponentesCurricularIds = componentesCurricularIds;
            ModalidadesIds = modalidadesIds;
            Modalidade = modalidade;
            TipoEscola = tipoEscola;
            AnoTurma = anoTurma;
            TipoConsultaProfessor = tipoConsulta;
        }
    }
}