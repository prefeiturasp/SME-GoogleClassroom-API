﻿using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoExtintoQueryHandler: IRequestHandler<ArquivarCursoExtintoQuery, bool>
    {
        private readonly IRepositorioCursoArquivado repositorioCursoArquivado;

        public ArquivarCursoExtintoQueryHandler(IRepositorioCursoArquivado repositorioCursoArquivado)
        {
            this.repositorioCursoArquivado = repositorioCursoArquivado ?? throw new ArgumentNullException(nameof(repositorioCursoArquivado));
        }

        public async Task<bool> Handle(ArquivarCursoExtintoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoArquivado.ArquivarCurso();

    }
}