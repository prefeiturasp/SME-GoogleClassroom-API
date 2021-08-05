namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterUsuariosQueSeraoRemovidosDto : FiltroPaginacaoBaseDto
    {
        public FiltroObterUsuariosQueSeraoRemovidosDto()
        {
        }

        public FiltroObterUsuariosQueSeraoRemovidosDto(string turmaId)
        {
            TurmaId = turmaId;
        }

        public string TurmaId { get; set; }
    }
}
