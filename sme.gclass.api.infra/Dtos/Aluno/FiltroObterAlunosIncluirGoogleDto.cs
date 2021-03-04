using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosIncluirGoogleDto : FiltroPaginacaoBaseDto
    {
        public long CodigoEol { get; set; }

        [Required]
        [DefaultValue("2021-02-20")]
        public DateTime UltimaExecucao { get; set; }
    }
}