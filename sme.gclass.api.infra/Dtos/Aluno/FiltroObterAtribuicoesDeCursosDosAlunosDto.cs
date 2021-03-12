using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAtribuicoesDeCursosDosAlunosDto : FiltroPaginacaoBaseDto
    {
        public long? CodigoAluno { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
