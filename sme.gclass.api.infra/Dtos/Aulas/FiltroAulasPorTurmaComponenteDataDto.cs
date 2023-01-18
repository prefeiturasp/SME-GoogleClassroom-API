using System;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAulasPorTurmaComponenteDataDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o código da turma")]
        public string TurmaCodigo { get; set; }
        
        [Required(ErrorMessage = "É necessário informar o código do componente curricular")]
        public long ComponenteCurricular { get; set; }
        
        [Required(ErrorMessage = "É necessário informar a data da aula")]
        public DateTime DataAula { get; set; }
    }
}