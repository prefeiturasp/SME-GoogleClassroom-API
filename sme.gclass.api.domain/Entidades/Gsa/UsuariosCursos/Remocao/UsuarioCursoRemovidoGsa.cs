using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioCursoRemovidoGsa
    {
        public UsuarioCursoRemovidoGsa(long usuarioId, long cursoId, UsuarioTipo usuarioTipo, DateTime removidoEm)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            UsuarioTipo = usuarioTipo;
            RemovidoEm = removidoEm;
        }
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public DateTime RemovidoEm { get; set; }
    }
}
