using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaRemoverCursoUsuarioDto
    {
        public FiltroTurmaRemoverCursoUsuarioDto(int anoLetivo, DateTime dataReferencia, IEnumerable<long> turmasIds, bool ehDataReferenciaPrincipal)
        {
            AnoLetivo = anoLetivo;
            DataReferencia = dataReferencia;
            TurmasIds = turmasIds;
            EhDataReferenciaPrincipal = ehDataReferenciaPrincipal;
        }

        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> TurmasIds { get; set; }
        public bool EhDataReferenciaPrincipal { get; set; }
    }
}
