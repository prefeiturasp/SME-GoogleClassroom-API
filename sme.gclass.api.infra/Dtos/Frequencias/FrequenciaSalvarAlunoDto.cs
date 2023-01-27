using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FrequenciaSalvarAlunoDto
    {
        [Required(ErrorMessage = "É necessário informar a matrícula do aluno para registrar a frequência.")]
        public string CodigoAluno { get; set; }
        
        public IEnumerable<FrequenciaAulaDto> Frequencias { get; set; }
    }
}