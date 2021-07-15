using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioInativo
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public DateTime InativadoEm { get; set; }

        public UsuarioInativo()
        {

        }

        public UsuarioInativo(long usuarioId)
        {
            UsuarioId = usuarioId;
            UsuarioTipo = UsuarioTipo.Aluno;
            InativadoEm = DateTime.Now;
        }
    }
}
