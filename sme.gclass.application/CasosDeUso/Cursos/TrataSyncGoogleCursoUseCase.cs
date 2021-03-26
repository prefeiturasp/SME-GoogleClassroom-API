using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoUseCase : ITrataSyncGoogleCursoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var ultimaExecucaoCursosIncluir = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoAdicionar));

            var cursosParaAdicionar = await mediator.Send(new ObterCursosIncluirGoogleQuery(ultimaExecucaoCursosIncluir, new Paginacao(0, 0), null, null));
            if (cursosParaAdicionar != null && cursosParaAdicionar.Items.Any())
            {
                foreach (var cursoParaAdicionar in cursosParaAdicionar.Items)
                {
                    try
                    {
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoParaAdicionar));
                    }
                    catch (Exception ex)
                    {
                        SentrySdk.CaptureException(ex);
                        await mediator.Send(new InserirCursoErroCommand(cursoParaAdicionar.TurmaId, cursoParaAdicionar.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                    }
                }
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoAdicionar));
            return true;
        }
    }
}
