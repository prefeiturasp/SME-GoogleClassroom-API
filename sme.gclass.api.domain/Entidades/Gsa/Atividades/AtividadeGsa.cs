using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AtividadeGsa
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public AtividadeGsa()
        {
        }

        public AtividadeGsa(long id, string titulo, string descricao, long usuarioId, long cursoId, DateTime dataInclusao, DateTime dataAlteracao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            UsuarioId = usuarioId;
            CursoId = cursoId;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }
    }
}
