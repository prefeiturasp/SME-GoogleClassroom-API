using System;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosQueSeraoInativadosDto : FiltroPaginacaoBaseDto
    {
        [Required(ErrorMessage = "O ano letivo deve ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ano letivo deve ser informado.")]
        public int AnoLetivo { get; set; }

        [Required(ErrorMessage = "A data de referência deve ser informada.")]
        public DateTime DataReferencia { get; set; }
    }
}
