namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterFuncionariosIndiretosCadastradosDto : FiltroPaginacaoBaseDto
    {
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}