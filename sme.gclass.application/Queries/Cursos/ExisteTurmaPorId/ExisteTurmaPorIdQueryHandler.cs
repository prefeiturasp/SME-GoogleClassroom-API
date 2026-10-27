using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaPorIdQueryHandler : IRequestHandler<ExisteTurmaPorIdQuery, bool>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ExisteTurmaPorIdQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<bool> Handle(ExisteTurmaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ExisteTurmaPorId(request.TurmaId);
        }
    }
}
