using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQueryHandler : IRequestHandler<ObterCursosIncluirGoogleQuery, PaginacaoResultadoDto<CursoParaInclusaoDto>>
    {

        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }
        public async Task<PaginacaoResultadoDto<CursoParaInclusaoDto>> Handle(ObterCursosIncluirGoogleQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ObterCursosParaInclusao(request.UltimaExecucao, request.Paginacao);
        }
    }
}
