using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class IniciarSyncGoogleCursoDto
    {
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }

        public IniciarSyncGoogleCursoDto(long? turmaId, long? componenteCurricularId)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public bool Valido => TurmaId.HasValue || ComponenteCurricularId.HasValue;
    }
}