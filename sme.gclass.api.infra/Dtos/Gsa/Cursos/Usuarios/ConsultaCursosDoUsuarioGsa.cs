using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class ConsultaCursosDoUsuarioGsa
    {
        public string UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public ICollection<CursoDoUsuarioDto> Cursos { get; set; }
    }
}