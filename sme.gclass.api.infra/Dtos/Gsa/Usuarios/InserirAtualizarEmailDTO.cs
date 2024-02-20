using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class InserirAtualizarEmailDTO
    {
        public IEnumerable<UsuarioEmailDto> Usuarios { get; set; }
    }
}