using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public abstract class FiltroPaginacaoBaseDto
    {
        [Required]
        public int PaginaNumero { get; set; }

        [Required]
        public int RegistrosQuantidade { get; set; }

    }
}
