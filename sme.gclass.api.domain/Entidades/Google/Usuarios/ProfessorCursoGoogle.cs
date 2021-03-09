using System;

namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorCursoGoogle
    {
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string Email { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
