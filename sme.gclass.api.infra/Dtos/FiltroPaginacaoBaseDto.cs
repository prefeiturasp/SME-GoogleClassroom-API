using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public abstract class FiltroPaginacaoBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PaginaNumero { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de registros deve ser maior que zero.")]
        public int RegistrosQuantidade { get; set; }

    }
}
