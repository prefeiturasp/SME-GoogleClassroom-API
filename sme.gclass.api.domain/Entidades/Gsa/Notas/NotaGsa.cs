using System;

namespace SME.GoogleClassroom.Dominio
{
    public class NotaGsa
    {
        public NotaGsa() { }

        public NotaGsa(long id, long atividadeId, long usuarioId, double nota, DateTime dataInclusao, DateTime? dataAlteracao)
        {
            Id = id;
            AtividadeId = atividadeId;
            UsuarioId = usuarioId;
            Nota = nota;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }

        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public long UsuarioId { get; set; }
        public double Nota { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
