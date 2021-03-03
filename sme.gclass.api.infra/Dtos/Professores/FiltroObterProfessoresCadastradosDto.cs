namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterProfessoresCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? Rf { get; set; }
        public string Email { get; set; }
    }
}