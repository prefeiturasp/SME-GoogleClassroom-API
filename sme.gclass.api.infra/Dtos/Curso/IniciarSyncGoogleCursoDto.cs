namespace SME.GoogleClassroom.Infra
{
    public class IniciarSyncGoogleCursoDto
    {
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