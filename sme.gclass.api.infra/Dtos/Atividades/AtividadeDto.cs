using System;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class AtividadeDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UsuarioGsaId { get; set; }
        public long CursoGsaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double NotaMaxima { get; set; }

        public AtividadeDto()
        {
        }

        public AtividadeDto(AtividadeGsa atividade)
        {
            if (atividade == null) return;

            Id = atividade.Id;
            Titulo = atividade.Titulo;
            Descricao = atividade.Descricao;
            UsuarioGsaId = atividade.UsuarioGsaId;
            CursoGsaId = atividade.CursoGsaId;
            DataInclusao = atividade.DataInclusao;
            DataAlteracao = atividade.DataAlteracao;
            DataEntrega = atividade.DataEntrega;
            NotaMaxima = atividade.NotaMaxima;
        }
    }
}
