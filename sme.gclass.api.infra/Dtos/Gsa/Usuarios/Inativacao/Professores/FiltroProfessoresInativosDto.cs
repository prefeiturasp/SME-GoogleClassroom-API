using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroProfessoresInativosDto
    {
        public FiltroProfessoresInativosDto(DateTime dataReferencia, IEnumerable<long> ids)
        {
            DataReferencia = dataReferencia;
            Ids = ids;
        }

        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> Ids { get; set; }
    }
}
