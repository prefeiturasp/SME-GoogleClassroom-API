using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaRemoverCursoUsuarioDto
    {
        public CarregarTurmaRemoverCursoUsuarioDto(int anoLetivo, DateTime dataReferencia, int pagina, int totalRegistros)
        {
            AnoLetivo = anoLetivo;
            DataReferencia = dataReferencia;
            Pagina = pagina;
            TotalRegistros = totalRegistros;
        }

        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
        public int Pagina { get; set; }
        public int TotalRegistros { get; set; }
    }
}
