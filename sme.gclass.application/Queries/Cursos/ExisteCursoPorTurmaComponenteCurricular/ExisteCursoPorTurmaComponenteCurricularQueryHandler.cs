using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoPorTurmaComponenteCurricularQueryHandler : IRequestHandler<ExisteCursoPorTurmaComponenteCurricularQuery, bool>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ExisteCursoPorTurmaComponenteCurricularQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso;
        }
        public async Task<bool> Handle(ExisteCursoPorTurmaComponenteCurricularQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCurso.ExisteCursoPorTurmaComponenteCurricular(request.TurmaId, request.ComponenteCurricularId);
        }
    }
}
