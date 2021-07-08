using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaRemoverCursoUsuarioDto
    {
        public FiltroTurmaRemoverCursoUsuarioDto(int anoLetivo, DateTime dataReferencia, IEnumerable<long> turmasIds)
        {
            AnoLetivo = anoLetivo;
            DataReferencia = dataReferencia;
            TurmasIds = turmasIds;
        }

        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> TurmasIds { get; set; }
    }
}
