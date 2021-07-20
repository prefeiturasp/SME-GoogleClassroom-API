using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto()
        {

        }

        public CarregarTurmaRemoverCursoUsuarioDto(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
