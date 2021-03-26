using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaAtivaPorIdQueryHandler : IRequestHandler<ExisteTurmaAtivaPorIdQuery, bool>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ExisteTurmaAtivaPorIdQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<bool> Handle(ExisteTurmaAtivaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ExisteTurmaAtivaPorId(request.TurmaId);
        }
    }
}
