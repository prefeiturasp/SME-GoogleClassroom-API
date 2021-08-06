using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroProfessoresEFuncionarioInativosDto
    {
        public FiltroProfessoresEFuncionarioInativosDto(DateTime dataReferencia, IEnumerable<long> rfs, IEnumerable<string> cpfs)
        {
            DataReferencia = dataReferencia;
            Rfs = rfs;
            Cpfs = cpfs;
        }

        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> Rfs { get; set; }
        public IEnumerable<string> Cpfs { get; set; }
    }
}
