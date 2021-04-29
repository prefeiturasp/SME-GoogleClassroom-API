using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ProcessarSincronizacaoComparativoCursoUseCase : IProcessarSincronizacaoComparativoCursoUseCase
    {
        private readonly IMediator mediator;

        public ProcessarSincronizacaoComparativoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var comparativoCurso = JsonConvert.DeserializeObject<CursoComparativo>(mensagemRabbit.Mensagem.ToString());
            if (comparativoCurso is null) return false;

            try
            {
                var cursoGoogle = await mediator.Send(new ObterCursoGooglePorIdQuery(Convert.ToInt64(comparativoCurso.Id)));
                comparativoCurso.InseridoManualmenteGoogle = cursoGoogle is null;
                var retorno =  await mediator.Send(new InserirComparativoCursoCommand(comparativoCurso));

                if (comparativoCurso.UltimoItemDaFila)
                    await IniciarValidacaoAsync();

                return retorno;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
            return false;
        }

        private async Task IniciarValidacaoAsync()
        {
            try
            {
                var iniciarFilaDeValidacao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaComparativoCursoValidar, RotasRabbit.FilaComparativoCursoValidar, true));
                if (!iniciarFilaDeValidacao)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a fila de validação de cursos.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}