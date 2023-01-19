using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FrequenciaAulaDto
    {
        [Required(ErrorMessage = "É necessário informar o tipo de frequência (C-Presença , F-Falta, R-Remoto) para registro de frequência.")]
        [RegularExpression(@"^[c|f|r|C|F|R''-'\s]{1}$", ErrorMessage = "É necessário informar o tipo de frequência (C-Presença , F-Falta, R-Remoto) para registro de frequência.")]
        public string TipoFrequencia { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "É necessário informar o número da aula para registro de frequência.")]
        public int NumeroAula { get; set; }
    }
}