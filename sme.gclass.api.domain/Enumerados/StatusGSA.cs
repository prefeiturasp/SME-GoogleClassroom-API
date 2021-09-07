using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio
{
    public enum StatusGSA
    {
        [Display(Name = "NaoEspecificado")]
        SUBMISSION_STATE_UNSPECIFIED = 0,
        [Display(Name = "Novo")]
        NEW = 1,
        [Display(Name = "Criado")]
        CREATED = 2,
        [Display(Name = "Entregue")]
        TURNED_IN = 3  ,  
        [Display(Name = "Devolvido")]
        RETURNED = 4,
        [Display(Name = "ReclamadaPeloAluno")]
        RECLAIMED_BY_STUDENT = 5
    }
}
