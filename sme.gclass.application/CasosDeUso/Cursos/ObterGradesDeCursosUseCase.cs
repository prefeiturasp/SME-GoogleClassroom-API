using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesDeCursosUseCase : IObterGradesDeCursosUseCase
    {
        private readonly IMediator mediator;

        public ObterGradesDeCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<GradeCursoEol>> Executar(FiltroObterGradesDeCursosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            return await mediator.Send(new ObterGradesDeCursosQuery(filtro.DataReferencia, paginacao, filtro.TurmaId, filtro.ComponenteCurricularId, parametrosCargaInicialDto));
        }
    }
}