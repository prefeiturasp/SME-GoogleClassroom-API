﻿using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComResponsaveisPorAnoQueryHandler : IRequestHandler<ObterCursosComResponsaveisPorAnoQuery, IEnumerable<CursoResponsavelDto>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterCursosComResponsaveisPorAnoQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new System.ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<IEnumerable<CursoResponsavelDto>> Handle(ObterCursosComResponsaveisPorAnoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.ObterCursosComResponsaveisPorAno(request.AnoLetivo);
    }
}