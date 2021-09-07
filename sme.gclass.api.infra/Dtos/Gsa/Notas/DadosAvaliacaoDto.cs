﻿using System;

namespace SME.GoogleClassroom.Infra
{
    public class DadosAvaliacaoDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public long TurmaId { get; set; }
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public DateTime? DataEntrega { get; set; }
        public double? NotaMaxima { get; set; }

        public DadosAvaliacaoDto()
        {
        }

        public DadosAvaliacaoDto(long id, string Titulo, long turmaId, long usuarioId, long cursoId, DateTime dataInclusao, DateTime dataAlteracao, DateTime? dataEntrega, double? notaMaxima)
        {
            Id = id;
            this.Titulo = Titulo;
            TurmaId = turmaId;
            UsuarioId = usuarioId;
            CursoId = cursoId;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
            DataEntrega = dataEntrega;
            NotaMaxima = notaMaxima;
        }
    }
}
