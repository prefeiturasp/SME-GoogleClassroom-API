using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAlunosInativosDto : FiltroPaginacaoBaseDto
    {
        [Required(ErrorMessage = "O tipo de usuário deve ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "O tipo de usuário deve ser informado.")]
        public int UsuarioTipo { get; set; }
    }
}
