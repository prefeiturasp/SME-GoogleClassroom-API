using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAtividadesDto : FiltroPaginacaoBaseDto
    {
        public long? CursoId { get; set; }

        [Required]
        [DefaultValue("2021-02-20")]
        public DateTime DataReferencia { get; set; }
    }
}