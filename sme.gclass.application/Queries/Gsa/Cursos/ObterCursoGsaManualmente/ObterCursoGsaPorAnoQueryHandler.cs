using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaPorNomeQueryHandler : IRequestHandler<ObterCursoGsaPorNomeQuery, CursoGsaDto>
    {
        IRepositorioCursoGsa repositorioCursoGsa;
        public ObterCursoGsaPorNomeQueryHandler(IRepositorioCursoGsa repositorioCursoGsa)
        {
            this.repositorioCursoGsa = repositorioCursoGsa ?? throw new ArgumentNullException(nameof(repositorioCursoGsa));
        }
        public async Task<CursoGsaDto> Handle(ObterCursoGsaPorNomeQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoGsa.ObterCursoGsaPorNomeAsync(request.Nome);
        }
    }
}
