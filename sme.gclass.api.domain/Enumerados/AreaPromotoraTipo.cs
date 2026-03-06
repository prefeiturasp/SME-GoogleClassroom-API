using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio
{
    public enum AreaPromotoraTipo
    {
        [Display(Name = "COPED - Núcleo de Formação")]
        CopedNucleoFormacao = 1,

        [Display(Name = "EMFORPEF")]
        Emforpef = 41
    }
}
