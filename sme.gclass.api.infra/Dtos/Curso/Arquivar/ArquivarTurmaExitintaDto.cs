using System;

namespace SME.GoogleClassroom.Infra
{
    public class ArquivarTurmaExitintaDto
    {
        public long TurmaId { get; set; }
        public DateTime DataExtincao { get; set; }
        public bool Excluir { get; set; }
    }
}
