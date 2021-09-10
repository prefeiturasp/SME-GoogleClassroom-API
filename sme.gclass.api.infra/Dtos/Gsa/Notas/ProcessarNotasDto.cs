using System;

namespace SME.GoogleClassroom.Infra
{
    public class ProcessarNotasDto
    {
        public int TotalDiasImportacao { get; set; }
        public string NotaId { get; set; }
        public DateTime DataCriacaoAtividade { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool LancaNota { get; set; }
        public long AtividadeId { get; set; }
        public string UsuarioId { get; set; }
        public double? Nota { get; set; }
        public string StatusNota { get; set; }
        public double? NotaMaxima { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string TituloAtividade { get; set; }
    }
}
