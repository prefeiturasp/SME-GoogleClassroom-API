using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AvisoGsa
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public long UsuarioId { get;  set; }
        public long CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public AvisoGsa()
        {
        }

        public AvisoGsa(long id, string texto, long usuarioId, long cursoId, DateTime dataInclusao, DateTime dataAlteracao)
        {
            Id = id;
            Texto = texto;
            UsuarioId = usuarioId;
            CursoId = cursoId;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }
    }
}