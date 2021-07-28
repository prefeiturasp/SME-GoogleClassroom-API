using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterProfessoresQueSeraoRemovidosDto : FiltroPaginacaoBaseDto
    {
        public FiltroObterProfessoresQueSeraoRemovidosDto()
        {
        }

        public FiltroObterProfessoresQueSeraoRemovidosDto(string turmaId)
        {
            TurmaId = turmaId;
        }

        public string TurmaId { get; set; }
    }
}
