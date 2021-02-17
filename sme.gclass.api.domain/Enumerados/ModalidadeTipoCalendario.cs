using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio
{
    public enum ModalidadeTipoCalendario
    {
        [Display(Name = "Fundamental/Médio")]
        FundamentalMedio = 1,

        [Display(Name = "EJA")]
        EJA = 2,

        [Display(Name = "Infantil")]
        Infantil = 3
    }
}
