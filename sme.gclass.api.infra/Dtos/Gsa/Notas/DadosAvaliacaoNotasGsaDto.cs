using System;

namespace SME.GoogleClassroom.Infra
{
    public class DadosAvaliacaoNotasGsaDto
    {
        public DadosAvaliacaoNotasGsaDto(long turmaId, long componenteCurricularId, long cursoId, long atividadeId, DateTime dataCriacao, DateTime? dataEntrega, bool lancaNota, double? notaMaxima, int totalDiasImportacao, string tituloAtividade)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            CursoId = cursoId;
            AtividadeId = atividadeId;
            DataCriacao = dataCriacao;
            DataEntrega = dataEntrega;
            LancaNota = lancaNota;
            NotaMaxima = notaMaxima;
            TotalDiasImportacao = totalDiasImportacao;
            TituloAtividade = tituloAtividade;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long CursoId { get; set; }
        public long AtividadeId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool LancaNota { get; set; }
        public double? NotaMaxima { get; set; }
        public int TotalDiasImportacao { get; set; }
        public string TituloAtividade { get; set; }
    }
}
