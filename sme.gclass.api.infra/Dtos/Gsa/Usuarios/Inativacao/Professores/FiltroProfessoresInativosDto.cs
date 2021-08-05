using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroProfessoresInativosDto
    {
        public FiltroProfessoresInativosDto(DateTime dataReferencia, IEnumerable<long> rfs)
        {
            DataReferencia = dataReferencia;
            Rfs = rfs;
        }

        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> Rfs { get; set; }
    }
}
