using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGsaCommandHandler : IRequestHandler<InserirCursoGsaCommand, bool>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public InserirCursoGsaCommandHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo ?? throw new ArgumentNullException(nameof(repositorioCursoComparativo));
        }

        public async Task<bool> Handle(InserirCursoGsaCommand request, CancellationToken cancellationToken)
        {
            var cursoIncluido = await repositorioCursoComparativo.SalvarAsync(request.CursoGsa);
            return cursoIncluido > 0;
        }
    }
}