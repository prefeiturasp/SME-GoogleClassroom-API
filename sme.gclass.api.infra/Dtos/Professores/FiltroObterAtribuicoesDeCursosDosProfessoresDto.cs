using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAtribuicoesDeCursosDosProfessoresDto : FiltroPaginacaoBaseDto
    {
        public long? Rf { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
