using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoCursoGoogle
    {
        public AlunoCursoGoogle()
        {

        }
        public AlunoCursoGoogle(long usuarioId, long cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            DataInclusao = DateTime.Now;
        }

        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
