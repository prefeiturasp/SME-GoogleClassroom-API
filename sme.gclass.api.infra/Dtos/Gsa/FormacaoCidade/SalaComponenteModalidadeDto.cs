namespace SME.GoogleClassroom.Infra
{
    public class SalaComponenteModalidadeDto
    {
        public string SalaVirtual { get; set; }
        public string ComponentesCurricularIds { get; set; }
        public int Modalidade { get; set; }

        public SalaComponenteModalidadeDto(string salaVirtual, string componentesCurricularIds, int modalidade)
        {
            SalaVirtual = salaVirtual;
            ComponentesCurricularIds = componentesCurricularIds;
            Modalidade = modalidade;
        }
    }
}