using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto()
        {
        }

        public CarregarTurmaRemoverCursoUsuarioDto(DateTime dataInicio, DateTime dataFim, int pagina, int totalRegistros)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            Pagina = pagina;
            TotalRegistros = totalRegistros;
        }

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public int Pagina { get; set; }
        public int TotalRegistros { get; set; }
    }
}
