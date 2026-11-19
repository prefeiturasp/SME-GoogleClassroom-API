using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaPorCodigoQueryHandler : IRequestHandler<ExisteTurmaPorCodigoQuery, bool>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ExisteTurmaPorCodigoQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<bool> Handle(ExisteTurmaPorCodigoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ExisteTurmaPorCodigo(request.TurmaId);
        }
    }
}
