using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterIdsCursosPorTurmaQueryHandler : IRequestHandler<ObterIdsCursosPorTurmaQuery, IEnumerable<long>>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterIdsCursosPorTurmaQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<IEnumerable<long>> Handle(ObterIdsCursosPorTurmaQuery request, CancellationToken cancellationToken)
            => await repositorioCurso.ObterIdsCursosPorTurma(request.TurmaId);
    }
}
