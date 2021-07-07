using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAvisoDto: FiltroPaginacaoBaseDto
    {
        [Required]
        [DefaultValue("2021-07-07")]
        public DateTime DataReferencia { get; set; }
        public string UsuarioId { get; set; }
        public long? CursoId { get; set; }
    }
}
