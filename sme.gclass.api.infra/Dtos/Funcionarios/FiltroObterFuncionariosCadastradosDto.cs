namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterFuncionariosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public long? Rf { get; set; }
        public string Email { get; set; }
    }
}