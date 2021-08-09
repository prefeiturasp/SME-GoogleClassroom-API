using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarProfessoresEFuncionariosInativosDto
    {
        public DateTime DataReferencia { get; set; }
        public string Rf { get; set; }
        public string Cpf { get; set; }
        public bool ProcessarProfessoresEFuncionarios { get; set; }
        public bool ProcessarFuncionariosIndiretos { get; set; }



        public CarregarProfessoresEFuncionariosInativosDto(DateTime dataReferencia, string rf, string cpf, bool processarProfessoresEFuncionarios, bool processarFuncionariosIndiretos)
        {
            DataReferencia = dataReferencia;
            Rf = rf;
            Cpf = cpf;
            ProcessarProfessoresEFuncionarios = processarProfessoresEFuncionarios;
            ProcessarFuncionariosIndiretos = processarFuncionariosIndiretos;
        }
    }
}
