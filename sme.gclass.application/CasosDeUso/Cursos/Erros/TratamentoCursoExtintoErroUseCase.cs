using System;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratamentoCursoExtintoErroUseCase : ITratamentoCursoExtintoErroUseCase
    {
        private readonly IMediator mediator;

        public TratamentoCursoExtintoErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var cursoExtintoErro = JsonConvert.DeserializeObject<CursoArquivarErro>(mensagemRabbit.Mensagem.ToString());
            if (cursoExtintoErro is null) return true;

            try
            {
                var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(
                    RotasRabbit.FilaCursoExtintoArquivarSync, RotasRabbit.FilaCursoExtintoArquivarSync,
                    cursoExtintoErro));
                if (!publicarCurso)
                {
                    SentrySdk.CaptureMessage(
                        $"Não foi possível arquivar curso com o id {cursoExtintoErro.CursoId} na fila de sincronização");
                }
            }
            catch (Exception ex)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(
                    RotasRabbit.FilaCursoExtintoArquivarErroTratar, RotasRabbit.FilaCursoExtintoArquivarErroTratar,
                    cursoExtintoErro));
                SentrySdk.CaptureException(ex);
            }

            return true;
        }
    }
}