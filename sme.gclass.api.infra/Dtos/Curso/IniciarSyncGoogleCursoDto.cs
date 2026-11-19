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
        public int Pagina { get; set; }

        public IniciarSyncGoogleCursoDto()
        {
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
            Pagina = 1;
        }

        public IniciarSyncGoogleCursoDto(long? turmaId, long? componenteCurricularId, int pagina = 1)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Pagina = pagina;
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }

        public bool Valido => TurmaId.HasValue || ComponenteCurricularId.HasValue;
    }
}