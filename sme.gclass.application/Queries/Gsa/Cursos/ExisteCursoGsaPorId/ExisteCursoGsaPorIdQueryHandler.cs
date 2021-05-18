using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoGsaPorIdQueryHandler : IRequestHandler<ExisteCursoGsaPorIdQuery, bool>
    {
        private readonly IRepositorioCursoGsa repositorioCursoGsa;

        public ExisteCursoGsaPorIdQueryHandler(IRepositorioCursoGsa repositorioCursoGsa)
        {
            this.repositorioCursoGsa = repositorioCursoGsa;
        }

        public async Task<bool> Handle(ExisteCursoGsaPorIdQuery request, CancellationToken cancellationToken)
            => await repositorioCursoGsa.ExistePorIdAsync(request.UsuarioId);
    }
}