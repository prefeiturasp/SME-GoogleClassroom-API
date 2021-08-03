using System;

namespace SME.GoogleClassroom.Infra
{
    public class VigenciaDto
    {
        public VigenciaDto(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
