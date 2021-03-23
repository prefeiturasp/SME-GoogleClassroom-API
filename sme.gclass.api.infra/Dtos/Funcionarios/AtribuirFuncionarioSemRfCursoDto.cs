using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class AtribuirFuncionarioSemRfCursoDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }
        [Required]
        public long TurmaId { get; set; }
        [Required]
        public long ComponenteCurricularId { get; set; }
    }
}
