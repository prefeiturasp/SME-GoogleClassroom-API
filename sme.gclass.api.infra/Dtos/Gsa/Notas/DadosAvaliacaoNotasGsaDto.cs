using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class DadosAvaliacaoNotasGsaDto
    {
        public DadosAvaliacaoNotasGsaDto(long cursoId, long atividadeId, DateTime dataCriacao, DateTime? dataEntrega, double? notaMaxima, int totalDiasImportacao, bool lancaNota = false)
        {
            CursoId = cursoId;
            AtividadeId = atividadeId;
            DataCriacao = dataCriacao;
            DataEntrega = dataEntrega;
            LancaNota = lancaNota;
            TotalDiasImportacao = totalDiasImportacao;
            NotaMaxima = notaMaxima;
        }

        public long CursoId { get; set; }
        public long AtividadeId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool LancaNota { get; set; }
        public double? NotaMaxima { get; set; }
        public int TotalDiasImportacao { get; set; }
    }
}
