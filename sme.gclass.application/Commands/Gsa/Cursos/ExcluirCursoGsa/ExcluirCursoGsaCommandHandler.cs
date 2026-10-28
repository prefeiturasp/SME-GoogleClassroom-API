using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoGsaCommandHandler : IRequestHandler<ExcluirCursoGsaCommand, bool>
    {
        private readonly IRepositorioCursoGsa repositorioCursoGsa;

        public ExcluirCursoGsaCommandHandler(IRepositorioCursoGsa repositorioCursoGsa)
        {
            this.repositorioCursoGsa = repositorioCursoGsa ?? throw new ArgumentNullException(nameof(repositorioCursoGsa));
        }

        public async Task<bool> Handle(ExcluirCursoGsaCommand request, CancellationToken cancellationToken)
        {
            return await repositorioCursoGsa.ExcluirCursoGsaAsync(request.CursoId);
        }
    }
}
