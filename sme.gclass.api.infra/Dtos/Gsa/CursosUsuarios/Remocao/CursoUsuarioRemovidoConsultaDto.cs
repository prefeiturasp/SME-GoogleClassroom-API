using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoUsuarioRemovidoConsultaDto
    {
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public string UsuarioGsaId { get; set; }
        public DateTime RemovidoEm { get; set; }
        public string EmailUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeCurso { get; set; }
    }
}
