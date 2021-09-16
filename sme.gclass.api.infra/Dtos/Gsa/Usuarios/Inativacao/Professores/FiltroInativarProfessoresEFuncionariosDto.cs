namespace SME.GoogleClassroom.Infra
{
    public class FiltroInativarProfessoresEFuncionariosDto
    {
        public string Cpf { get; set; }
        public string Rf { get; set; }
        public bool ProcessarProfessoresEFuncionarios { get; set; }
        public bool ProcessarFuncionariosIndiretos { get; set; }

        public FiltroInativarProfessoresEFuncionariosDto(string rf = null, string cpf = null, bool processarProfessoresEFuncionarios = false, bool processarFuncionariosIndiretos = false)
        {
            Rf = rf;
            Cpf = cpf;
            ProcessarProfessoresEFuncionarios = processarProfessoresEFuncionarios;
            ProcessarFuncionariosIndiretos = processarFuncionariosIndiretos;
        }
    }
}
