using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto(long? turmaId)
        {
            TurmaId = turmaId;
        }

        public long?  TurmaId { get; set; }
    }
}
