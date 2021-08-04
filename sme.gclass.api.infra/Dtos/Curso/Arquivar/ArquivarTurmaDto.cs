using System;

namespace SME.GoogleClassroom.Infra
{
    public class ArquivarTurmaDto
    {
        public ArquivarTurmaDto(long turmaId, DateTime dataExtincao, bool excluir)
        {
            TurmaId = turmaId;
            DataExtincao = dataExtincao;
            Excluir = excluir;
        }

        public long TurmaId { get; set; }
        public DateTime DataExtincao { get; set; }
        public bool Excluir { get; set; }
    }
}
