using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTurmaRemoverCursoUsuarioDto
    {
        public FiltroTurmaRemoverCursoUsuarioDto(DateTime dataInicio, DateTime dataFim, long turmaId)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            TurmaId = turmaId;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public long TurmaId { get; set; }
    }
}
