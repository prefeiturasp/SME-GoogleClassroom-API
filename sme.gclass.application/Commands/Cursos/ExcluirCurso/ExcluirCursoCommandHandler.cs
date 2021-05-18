using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoCommandHandler : IRequestHandler<ExcluirCursoCommand, bool>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ExcluirCursoCommandHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso;
        }

        public async Task<bool> Handle(ExcluirCursoCommand request, CancellationToken cancellationToken)
            => await repositorioCurso.ExcluirCursoAsync(request.CursoId) > 0;
    }
}