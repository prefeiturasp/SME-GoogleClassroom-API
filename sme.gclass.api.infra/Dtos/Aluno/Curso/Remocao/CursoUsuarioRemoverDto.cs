using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class CursoUsuarioRemoverDto
    {
        public long CursoId { get; set; }
        public long UsuarioId { get; set; }
        public string CursoGsaId { get; set; }
        public string UsuarioGsaId { get; set; }
        public string EmailUsuario { get; set; }
    }
}
