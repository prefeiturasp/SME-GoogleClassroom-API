using MediatR;
using Newtonsoft.Json;
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
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a sincronização de cursos. A mensagem enviada é inválida.");

            var filtro = ObterFiltro(mensagemRabbit);
            var aplicarFiltro = filtro?.Valido ?? false;

            var ultimaExecucaoCursosIncluir = !aplicarFiltro
                ? await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.CursoAdicionar))
                : default(DateTime?);

            var cursosParaAdicionar = await mediator.Send(new ObterCursosIncluirGoogleQuery(ultimaExecucaoCursosIncluir, new Paginacao(0, 0), filtro?.ComponenteCurricularId, filtro?.TurmaId));
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

            if(!aplicarFiltro)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.CursoAdicionar));

            return true;
        }

        private IniciarSyncGoogleCursoDto ObterFiltro(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtro = JsonConvert.DeserializeObject<IniciarSyncGoogleCursoDto>(mensagemRabbit.Mensagem.ToString());
                return filtro;
            }
            catch
            {
                SentrySdk.CaptureMessage("A mensagem enviada para sincronização de cursos é inválida. O filtro não será aplicado.");
                return null;
            }
        }
    }
}
