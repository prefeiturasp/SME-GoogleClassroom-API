using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FrequenciaSalvarAlunoDto
    {
        public string CodigoAluno { get; set; }
        public IEnumerable<FrequenciaAulaDto> Frequencias { get; set; }
    }
}