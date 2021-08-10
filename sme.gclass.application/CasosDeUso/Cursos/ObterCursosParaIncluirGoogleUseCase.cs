using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaIncluirGoogleUseCase : IObterCursosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<PaginacaoResultadoDto<CursoEol>> Executar(FiltroObterCursosIncluirGoogleDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterCursosIncluirGoogleQuery(parametrosCargaInicialDto, filtro.UltimaExecucao, paginacao, filtro.ComponenteCurricularId, filtro.TurmaId));
        }
    }
}
