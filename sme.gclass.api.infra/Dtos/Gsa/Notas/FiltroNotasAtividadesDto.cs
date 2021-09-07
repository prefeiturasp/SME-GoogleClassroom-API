using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroNotasAtividadesDto : FiltroPaginacaoBaseDto
    {
        public long? AtividadeId { get; set; }

        [Required]
        [DefaultValue("2021-02-20")]
        public DateTime DataReferencia { get; set; }
    }
}
