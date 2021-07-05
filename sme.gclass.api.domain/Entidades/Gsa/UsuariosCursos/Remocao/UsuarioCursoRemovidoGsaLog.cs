using System;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioCursoRemovidoGsaLog
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public DateTime RemovidoEm { get; set; }
    }
}
