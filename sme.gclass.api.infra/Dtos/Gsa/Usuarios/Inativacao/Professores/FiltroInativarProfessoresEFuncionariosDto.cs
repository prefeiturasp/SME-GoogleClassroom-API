namespace SME.GoogleClassroom.Infra
{
    public class FiltroInativarProfessoresEFuncionariosDto
    {
        public FiltroInativarProfessoresEFuncionariosDto(string rf = null, string cpf = null)
        {
            Rf = rf;
            Cpf = cpf;
        }

        public string Cpf { get; set; }
        public string Rf { get; set; }
    }
}
