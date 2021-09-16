using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosPorPeriodoPaginadoQueryHandler : IRequestHandler<ObterCursosExtintosPorPeriodoPaginadoQuery, PaginacaoResultadoDto<CursoExtintoEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosExtintosPorPeriodoPaginadoQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<PaginacaoResultadoDto<CursoExtintoEolDto>> Handle(ObterCursosExtintosPorPeriodoPaginadoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ObterCursosExtintosPorPeriodoPaginado(request.ParametrosCargaInicialDto, request.DataInicio, request.DataFim, request.AnoLetivo, request.TurmaId, request.Paginacao);
        }
    }
}
