using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteComponenteCurricularPorIdQueryHandler : IRequestHandler<ExisteComponenteCurricularPorIdQuery, bool>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ExisteComponenteCurricularPorIdQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<bool> Handle(ExisteComponenteCurricularPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ExisteComponenteCurricularPorId(request.ComponenteCurricularId);
        }
    }
}
