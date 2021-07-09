using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Dominio
{
    public class UsuarioInativado
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public UsuarioTipo usuario_tipo { get; set; }
        public DateTime RemovidoEm { get; set; }
    }
}
