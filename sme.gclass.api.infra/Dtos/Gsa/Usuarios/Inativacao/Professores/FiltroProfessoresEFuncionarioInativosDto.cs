using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroProfessoresEFuncionarioInativosDto
    {
        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> Rfs { get; set; }
        public IEnumerable<string> Cpfs { get; set; }
        public bool ProcessarProfessoresEFuncionarios { get; set; }
        public bool ProcessarFuncionariosIndiretos { get; set; }

        public FiltroProfessoresEFuncionarioInativosDto(DateTime dataReferencia, IEnumerable<long> rfs, IEnumerable<string> cpfs, bool processarProfessoresEFuncionarios, bool processarFuncionariosIndiretos)
        {
            DataReferencia = dataReferencia;
            Rfs = rfs;
            Cpfs = cpfs;
            ProcessarProfessoresEFuncionarios = processarProfessoresEFuncionarios;
            ProcessarFuncionariosIndiretos = processarFuncionariosIndiretos;
        }
    }
}
