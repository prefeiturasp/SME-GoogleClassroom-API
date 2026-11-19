using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroNotasAtividadesDto : FiltroPaginacaoBaseDto
    {
        public long? AtividadeId { get; set; }

        [Required(ErrorMessage = "A data de importação deve ser informada.")]
        [DefaultValue("2021-02-20")]
        public DateTime DataImportacao { get; set; }
    }
}
