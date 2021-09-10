using System;

namespace SME.GoogleClassroom.Infra
{
    public class PeriodoDto
    {
        public PeriodoDto(DateTime inicio, DateTime fim)
        {
            Inicio = inicio;
            Fim = fim;
        }

        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
