using System;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioInativoDto
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public int UsuarioTipo { get; set; }
        public DateTime InativadoEm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UnidadeOrganizacional { get; set; }
        public string GoogleClassroomId { get; set; }
    }
}
