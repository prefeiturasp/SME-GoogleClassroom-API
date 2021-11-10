using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorIdsParaIntegracaoQueryHandler : IRequestHandler<ObterCursosPorIdsParaIntegracaoQuery, IEnumerable<CursoGoogleDtoParaIntegracao>>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursosPorIdsParaIntegracaoQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }
        public async Task<IEnumerable<CursoGoogleDtoParaIntegracao>> Handle(ObterCursosPorIdsParaIntegracaoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCurso.ObterCursosPorIdsParaIntegracaoAsync(request.CursosId);
        }
    }
}
