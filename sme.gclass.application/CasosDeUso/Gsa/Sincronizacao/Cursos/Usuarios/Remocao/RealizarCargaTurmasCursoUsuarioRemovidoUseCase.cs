using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaTurmasCursoUsuarioRemovidoUseCase : IRealizarCargaTurmasCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaTurmasCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaRemoverCursoUsuarioDto>();

            var datasReferencias = await ObterDatasReferencias();

            var turmas = await mediator.Send(new ObterTurmasIdsCadastradasQuery(DateTime.Now.Year, dto.TurmaId));
            if (turmas != null && turmas.Any())
            {
                foreach (var turma in turmas)
                {
                    var filtroTurma = new FiltroTurmaRemoverCursoUsuarioDto(datasReferencias.dataInicio, datasReferencias.dataFim, turma);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, filtroTurma));
                }
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar curso de turma id {dto.TurmaId} na base do GSA!");
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.UsuarioCursoRemover));
            return true;
        }

        private async Task<(DateTime dataInicio, DateTime dataFim)> ObterDatasReferencias()
        {
            var totalDiasConsiderar = 10;
            var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
            return (dataUltimaExecucao.AddDays(-totalDiasConsiderar), DateTime.Today.AddDays(-totalDiasConsiderar));
        }
    }
}
