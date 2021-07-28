using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosParaArquivarPaginadoUseCase : AbstractUseCase, IObterCursosExtintosParaArquivarPaginadoUseCase
    {
        public ObterCursosExtintosParaArquivarPaginadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoExtintoEolDto>> Executar(FiltroTurmasExtintasArquivarDto param)
        {
            var dataInicio = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(Dominio.ExecucaoTipo.ArquivarCursosTurmasExtintas));
            var dataFim = DateTime.Today;

            var paginacao = new Paginacao(param.PaginaNumero, param.RegistrosQuantidade);

            return await mediator.Send(new ObterCursosExtintosPorPeriodoPaginadoQuery(dataInicio, dataFim, dataFim.Year, param.TurmaId, paginacao));
        }
    }
}
