using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoPorNomeQueryHandler : IRequestHandler<ExisteCursoPorNomeQuery, long>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ExisteCursoPorNomeQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso;
        }
        public async Task<long> Handle(ExisteCursoPorNomeQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCurso.ExisteCursoPorNome(request.Nome);
        }
    }
}
