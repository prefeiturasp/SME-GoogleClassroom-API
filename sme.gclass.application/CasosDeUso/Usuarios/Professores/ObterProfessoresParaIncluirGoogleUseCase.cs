using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaIncluirGoogleUseCase : IObterProfessoresParaIncluirGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterProfessoresParaIncluirGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ProfessorEol>> Executar(FiltroObterProfessoresIncluirGoogleDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            return await mediator.Send(new ObterProfessoresParaIncluirGoogleQuery(filtro.UltimaExecucao, paginacao, filtro.Rf, parametrosCargaInicialDto));
        }
    }
}
