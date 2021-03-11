using System;

namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorCursoGoogle
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public ProfessorCursoGoogle(long usuarioId, long cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            DataInclusao = DateTime.Now;
        }

        protected ProfessorCursoGoogle()
        {

        }
    }
}
