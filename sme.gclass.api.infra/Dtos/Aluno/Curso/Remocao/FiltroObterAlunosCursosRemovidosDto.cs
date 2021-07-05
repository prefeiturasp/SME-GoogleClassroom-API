using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosCursosRemovidosDto : FiltroPaginacaoBaseDto
    {
        public string CursoId { get; set; }
    }
}
