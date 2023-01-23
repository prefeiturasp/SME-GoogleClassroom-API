using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio.Enumerados
{
    public enum Modalidade
    {
        [Display(Name = "Educação Infantil", ShortName = "EI")]
        EducacaoInfantil = 1,

        [Display(Name = "Educação de Jovens e Adultos", ShortName = "EJA")]
        EJA = 3,
        [Display(Name = "CIEJA", ShortName = "CIEJA")]
        CIEJA = 4,
        [Display(Name = "Ensino Fundamental", ShortName = "EF")]
        Fundamental = 5,

        [Display(Name = "Ensino Médio", ShortName = "EM")]
        Medio = 6,

        [Display(Name = "CMCT", ShortName = "CMCT")]
        CMCT = 7,

        [Display(Name = "MOVA", ShortName = "MOVA")]
        MOVA = 8,

        [Display(Name = "ETEC", ShortName = "ETEC")]
        ETEC = 9
    }
}
