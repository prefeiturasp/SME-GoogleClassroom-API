using System;

namespace SME.GoogleClassroom.Infra
{
    public class RetornoConsultaListagemTurmaComponenteDto
    {
        public string Id { get; set; }
        public string TurmaCodigo { get; set; }
        public string Modalidade { get; set; }
        public string NomeTurma { get; set; }
        public string Ano { get; set; }
        public string NomeComponenteCurricular { get; set; }
        public long ComponenteCurricularCodigo { get; set; }
        public string ComplementoTurmaEJA { get; set; }
        public long ComponenteCurricularTerritorioSaberCodigo { get; set; }
        public string Turno { get; set; }
        public bool TerritorioSaber { get; set; }
        public int TotalRegistros { get; set; }
        public string RegistroFuncional { get; set; }
        public bool Historica { get; set; }
        public int TipoEscola { get; set; }
        public string SituacaoTurmaEscola { get; set; }
        public DateTime DataStatusTurmaEscola { get; set; }
        public string CodigoEscola { get; set; }
        public int AnoLetivo { get; set; }
        public DateTime? DataDisponibizacao { get; set; }
    }
}
