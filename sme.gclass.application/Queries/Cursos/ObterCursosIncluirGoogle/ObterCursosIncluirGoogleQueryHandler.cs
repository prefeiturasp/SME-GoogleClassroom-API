using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQueryHandler : IRequestHandler<ObterCursosIncluirGoogleQuery, PaginacaoResultadoDto<CursoEol>>
    {

        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<PaginacaoResultadoDto<CursoEol>> Handle(ObterCursosIncluirGoogleQuery request, CancellationToken cancellationToken)
        {
            var anoLetivo = request.UltimaExecucao?.Year ?? DateTime.Now.Year;
            return await repositorioCursoEol.ObterCursosParaInclusao(request.ParametrosCargaInicialDto, request.UltimaExecucao, anoLetivo, request.Paginacao, request.ComponenteCurricularId, request.TurmaId);
        }
    }
}
