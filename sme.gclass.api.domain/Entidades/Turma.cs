using System;

namespace SME.GoogleClassroom.Dominio
{
    public class Turma
    {
        public string Ano { get; set; }
        public int AnoLetivo { get; set; }
        public string CodigoTurma { get; set; }
        public int TipoTurma { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long Id { get; set; }
        public Modalidade ModalidadeCodigo { get; set; }
        public ModalidadeTipoCalendario ModalidadeTipoCalendario
        {
            get => ModalidadeCodigo == Modalidade.EJA ?
                ModalidadeTipoCalendario.EJA :
                ModalidadeCodigo == Modalidade.Infantil ?
                    ModalidadeTipoCalendario.Infantil :
                    ModalidadeTipoCalendario.FundamentalMedio;
        }
        public string Nome { get; set; }
        public int QuantidadeDuracaoAula { get; set; }
        public int Semestre { get; set; }
        public int TipoTurno { get; set; }
        public string SerieEnsino { get; set; }
    }
}
