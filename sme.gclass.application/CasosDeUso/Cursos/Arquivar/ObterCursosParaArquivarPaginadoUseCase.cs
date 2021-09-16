using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaArquivarPaginadoUseCase : AbstractUseCase, IObterCursosParaArquivarPaginadoUseCase
    {
        public ObterCursosParaArquivarPaginadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoArquivarEolDto>> Executar(FiltroTurmasArquivarDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            return await mediator.Send(new ObterCursosParaArquivarPorAnoPaginadoQuery(filtro.anoLetivo, paginacao, parametrosCargaInicialDto));
        }
    }
}
