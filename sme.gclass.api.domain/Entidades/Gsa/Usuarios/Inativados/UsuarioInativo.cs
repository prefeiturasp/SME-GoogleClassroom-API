using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioInativo
    {
        public long Id { get; set; }
        public long UsuarioId { get; private set; }
        public UsuarioTipo UsuarioTipo { get; private set; }
        public DateTime InativadoEm { get; private set; }

        public UsuarioInativo(long usuarioId)
        {
            UsuarioId = usuarioId;
            UsuarioTipo = UsuarioTipo.Aluno;
            InativadoEm = DateTime.Now;
        }
    }
}
