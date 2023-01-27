using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio.Enumerados
{
    public enum CiejaTipoFuncao
    {
        [Display(Name = "CIEJA COORDENADOR GERAL", ShortName = "DIRETOR")]
        Diretor = 42,
        [Display(Name = "CIEJA ASSIST COORD GERAL", ShortName = "AD")]
        Ad = 43,
        [Display(Name = "CIEJA ASSIST PED E EDUCACIONAL", ShortName = "CP")]
        Cp = 44,
    }
}
