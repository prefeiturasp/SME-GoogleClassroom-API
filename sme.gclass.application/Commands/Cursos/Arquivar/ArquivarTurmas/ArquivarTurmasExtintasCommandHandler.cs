using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarTurmasExtintasCommandHandler : AsyncRequestHandler<ArquivarTurmasExtintasCommand>
    {
        private readonly IMediator mediator;

        public ArquivarTurmasExtintasCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(ArquivarTurmasExtintasCommand request, CancellationToken cancellationToken)
        {
            var dataReferencia = request.DataReferencia ?? DateTime.Today;
            var ano = dataReferencia.Year;
            var parametroSistema = await ObterParametroDeSistema(ano);

            var dataInicio = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ArquivarCursosTurmasExtintas));
            var dataFim = DateTime.Today;
            var turmasExtintas = await mediator.Send(new ObterCursosExtintosPorPeriodoQuery(request.ParametrosCargaInicialDto, dataInicio, dataFim, ano, request.TurmaId));

            foreach (var item in turmasExtintas)
            {
                var dto = new ArquivarTurmaDto(item.TurmaId, item.DataExtincao, DefinaExclusaoOuArquivamento(item.DataExtincao, DateTime.Parse(parametroSistema.Valor)));

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarTratar, dto));
            }
        }

        private bool DefinaExclusaoOuArquivamento(DateTime dataExtincao, DateTime dataInicioAnoLetivo)
            => (dataExtincao < dataInicioAnoLetivo);

        private async Task<ParametrosSistema> ObterParametroDeSistema(int anoLetivo)
        {
            var parametrosSistema = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema.InicioAnoLetivo, anoLetivo));

            if (parametrosSistema is null)
                throw new NegocioException($"Não localizado o parametro de data de inicio do ano letivo para o ano {anoLetivo}");

            return parametrosSistema;
        }
    }
}
