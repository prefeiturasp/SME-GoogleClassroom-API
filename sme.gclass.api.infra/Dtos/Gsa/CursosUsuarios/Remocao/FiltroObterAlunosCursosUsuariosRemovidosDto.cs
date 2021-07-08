using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosCursosUsuariosRemovidosDto : FiltroPaginacaoBaseDto
    {
        public string CursoId { get; set; }
    }
}
