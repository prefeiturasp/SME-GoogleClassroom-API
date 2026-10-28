using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAnoLetivoTurmaQueryHandler : IRequestHandler<ObterAnoLetivoTurmaQuery, int?>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterAnoLetivoTurmaQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<int?> Handle(ObterAnoLetivoTurmaQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterAnoLetivoTurmaAsync(request.TurmaId);
    }
}