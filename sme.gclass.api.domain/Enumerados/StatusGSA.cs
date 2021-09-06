using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio
{
    public enum StatusGSA
    {
        [Display(Name = "SUBMISSION_STATE_UNSPECIFIED")]
        NaoEspecificado = 0,
        [Display(Name = "NEW")]
        Novo = 1,
        [Display(Name = "CREATED")]
        Criado = 2,
        [Display(Name = "TURNED_IN")]
        Entregue = 3  ,  
        [Display(Name = "RETURNED")]
        Devolvido = 4,
        [Display(Name = "RECLAIMED_BY_STUDENT")]
        ReclamadaPeloAluno = 5
    }
}
