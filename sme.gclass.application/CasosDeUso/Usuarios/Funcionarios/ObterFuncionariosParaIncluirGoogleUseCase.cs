using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaIncluirGoogleUseCase : IObterFuncionariosParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> Executar(FiltroObterFuncionariosIncluirGoogleDto filtro)
        { 
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterFuncionariosParaIncluirGoogleQuery(filtro.UltimaExecucao, paginacao, filtro.Rf, parametrosCargaInicialDto));
        }
    }
}