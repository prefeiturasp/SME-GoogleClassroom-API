using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoUsuario
    {
        public CursoUsuario(long cursoId, long usuarioId)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
            DataInclusao = DateTime.Now;
            Excluido = false;
        }

        public long Id { get; set; }
        public long CursoId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Excluido { get; set; }
    }
}
