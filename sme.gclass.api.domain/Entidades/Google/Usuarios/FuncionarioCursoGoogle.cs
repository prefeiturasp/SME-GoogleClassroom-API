﻿using System;

namespace SME.GoogleClassroom.Dominio
{
    public class FuncionarioCursoGoogle
    {
        public FuncionarioCursoGoogle(long usuarioId, long cursoId, DateTime dataInclusao)
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