using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class RegistroFrequenciaAlunoDto
    {
        public RegistroFrequenciaAlunoDto()
        {
            Aulas = new List<FrequenciaAulaDto>();
        }

        public List<FrequenciaAulaDto> Aulas { get; set; }
        public string CodigoAluno { get; set; }
    }
}