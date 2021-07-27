using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarArquivamentoCursosExtintosUseCase : ICarregarArquivamentoCursosExtintosUseCase
    {
        private IMediator mediator;

        public CarregarArquivamentoCursosExtintosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(long? turmaId = null)
        {
            var parametroSistema = await ObterParametroDeSistema();

            var dataInicio = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ArquivarCursosTurmasExtintas));
            var dataFim = DateTime.Today;
            var cursosExtintos = await mediator.Send(new ObterCursosExtintosQueryPorPeriodoQuery(dataInicio, dataFim, parametroSistema.Ano, turmaId));

            foreach (var item in cursosExtintos)
            {
                var cursoExtinto = new ArquivarTurmaExtintaDto(item.TurmaId, item.DataExtincao, DefinaExclusaoOuArquivamento(item.DataExtincao, DateTime.Parse(parametroSistema.Valor)))

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarTratar,  cursoExtinto));
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ArquivarCursosTurmasExtintas));

            return true;
        }

        private async Task<ParametrosSistema> ObterParametroDeSistema()
        {
            var ano = new DateTime().Year;
            var parametrosSistema = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(ETipoParametroSistema.InicioAnoLetivo, ano));

            return parametrosSistema;
        }

        private bool DefinaExclusaoOuArquivamento(DateTime dataExtincao, DateTime dataInicioAnoLetivo)
            => (dataExtincao < dataInicioAnoLetivo);
    }
}
