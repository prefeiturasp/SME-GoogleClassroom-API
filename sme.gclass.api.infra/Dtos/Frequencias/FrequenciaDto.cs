using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FrequenciaDto
    {
        public FrequenciaDto(long aulaId)
        {
            AulaId = aulaId;
            ListaFrequencia = new List<RegistroFrequenciaAlunoDto>();
        }

        [Range(1, long.MaxValue, ErrorMessage = "A aula é obrigatória")]
        public long AulaId { get; set; }
        public IList<RegistroFrequenciaAlunoDto> ListaFrequencia { get; set; }
    }
}