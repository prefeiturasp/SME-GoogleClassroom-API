using System;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterFuncionariosQueSeraoInativadosDto : FiltroPaginacaoBaseDto
    {
        [Required]
        public DateTime DataReferencia { get; set; }

        public string CodigoRf { get; set; }
    }

    public class FiltroObterFuncionariosIndiretosQueSeraoInativadosDto : FiltroPaginacaoBaseDto
    {
        public string Cpf { get; set; }
    }
}
