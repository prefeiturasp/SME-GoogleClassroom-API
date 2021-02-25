using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaInclusaoQueryHandler : IRequestHandler<ObterCursosParaInclusaoQuery, IEnumerable<CursoParaInclusaoDto>>
    {
        private readonly IRepositorioCursoEol repositorioCurso;

        public ObterCursosParaInclusaoQueryHandler(IRepositorioCursoEol repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<IEnumerable<CursoParaInclusaoDto>> Handle(ObterCursosParaInclusaoQuery request, CancellationToken cancellationToken)
        {
            var cursosParaInclusao = await repositorioCurso.ObterCursosParaInclusao(request.UltimaDataExecucao);

            return cursosParaInclusao;
        }
    }
}
