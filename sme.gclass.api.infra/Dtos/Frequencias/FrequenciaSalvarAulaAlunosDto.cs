using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FrequenciaSalvarAulaAlunosDto
    {
        [Range(1, long.MaxValue, ErrorMessage = "É necessário informar a aula para registro de frequência.")]
        public long AulaId { get; set; }
        
        
        [Required(ErrorMessage = "É necessário informar o login (Rf) do usuário logado para registrar auditoria.")]
        public string UsuarioLogado { get; set; }
        
        
        [Required(ErrorMessage = "É necessário informar o perfil (Guid) do usuário logado para registrar auditoria.")]
        public string PerfilUsuario { get; set; }
        
        public IEnumerable<FrequenciaSalvarAlunoDto> Alunos { get; set; }
    }
}